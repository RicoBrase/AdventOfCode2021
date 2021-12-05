using System;
using System.IO;

namespace AdventOfCode._2021.Day04
{
    public class Day04Part2 : IDay
    {
        private const string INPUT = "inputs/day04_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var (drawnNumbers, boards) = Day04Common.ParseInput(input);

            var (winningBoard, winningNumber) = Day04Common.DrawUntilOneBoardHasNotWon(drawnNumbers, boards);
            var winningBoardScore = winningBoard.CalculateScore(winningNumber);
            

            Console.WriteLine($"Winning board score: {winningBoardScore}");
        }
    }
}