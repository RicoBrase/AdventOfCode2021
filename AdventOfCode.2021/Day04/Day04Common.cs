using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day04
{
    public static class Day04Common
    {
        public static (int[] drawnNumbers, List<BingoBoard> boards) ParseInput(string[] input)
        {
            var drawnNumbers = input[0]
                .Split(',')
                .Select(it => Convert.ToInt32(it))
                .ToArray();
            var boardData = new List<int[][]>();

            var inputToProcess = input.Skip(2).ToList();
            while (inputToProcess.Any())
            {
                var inputGroup = inputToProcess.TakeWhile(it => !string.IsNullOrWhiteSpace(it)).ToList();
                inputToProcess = inputToProcess.Skip(inputGroup.Count + 1).ToList();
                
                boardData.Add(
                    inputGroup
                        .Select(a =>
                            a.Trim()
                                .Split(' ')
                                .Where(it => !string.IsNullOrWhiteSpace(it))
                                .Select(b => Convert.ToInt32(b))
                                .ToArray())
                        .ToArray()
                    );
            }
            
            return (drawnNumbers, boardData.Select(it => new BingoBoard(it)).ToList());
        }

        public static (BingoBoard winningBoard, int drawnNumberOnWin) DrawUntilOneBoardWins(int[] drawnNumbers, List<BingoBoard> boards)
        {
            foreach (var drawnNumber in drawnNumbers)
            {
                foreach (var board in boards)
                {
                    board.DrawNumber(drawnNumber);
                    if (board.Won) return (board, drawnNumber);
                }
            }

            throw new Exception();
        }

        public static (BingoBoard winningBoard, int drawnNumberOnWin) DrawUntilOneBoardHasNotWon(int[] drawnNumbers,
            List<BingoBoard> boards)
        {
            foreach (var drawnNumber in drawnNumbers)
            {
                var boardsToProcess = boards.Where(it => !it.Won).ToList();

                foreach (var board in boardsToProcess)
                {
                    var preDrawCount = boards.Count(it => !it.Won);
                    board.DrawNumber(drawnNumber);
                    if (board.Won && boards.All(it => it.Won) && preDrawCount == 1) return (board, drawnNumber);
                }
            }

            throw new Exception();
        }

    }
}