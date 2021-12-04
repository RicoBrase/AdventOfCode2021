using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day04
{
    public class BingoBoard
    {

        public (int num, bool marked)[][] Board { get; private set; }
        
        public bool Won { get; private set; }
        
        public BingoBoard(int[][] board)
        {
            Board = board.Select(x => x.Select(y => (y, false)).ToArray()).ToArray();
        }

        public (int num, bool marked) GetFieldDataAt(int x, int y)
        {
            return Board[y][x];
        }

        public void DrawNumber(int drawnNumber)
        {
            for (var y = 0; y < Board.Length; y++)
            {
                for (var x = 0; x < Board[y].Length; x++)
                {
                    if (Board[y][x].num == drawnNumber)
                    {
                        Board[y][x].marked = true;

                        if (Board[y][0].marked && Board[y][1].marked && Board[y][2].marked && Board[y][3].marked &&
                            Board[y][4].marked)
                        {
                            Won = true;
                        }
                        
                        if (Board[0][x].marked && Board[1][x].marked && Board[2][x].marked && Board[3][x].marked &&
                            Board[4][x].marked)
                        {
                            Won = true;
                        }
                    }
                }
            }
        }

        public int[] GetAllUnmarked()
        {
            return Board
                .SelectMany(it => it)
                .Where(it => !it.marked)
                .Select(it => it.num)
                .ToArray();
        }
        
        public int[] GetAllMarked()
        {
            return Board
                .SelectMany(it => it)
                .Where(it => it.marked)
                .Select(it => it.num)
                .ToArray();
        }

        public int CalculateScore(int winningNumber)
        {
            return GetAllUnmarked().Sum() * winningNumber;
        }
    }
}