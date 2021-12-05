using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day04;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day04
{
    public class Day04Part2Tests
    {
        
        private static readonly int[] DrawnNumbers =
            {7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1};

        private static List<int[][]> Boards => new()
        {
        new [] {
            new[]{22, 13, 17, 11, 0},
            new[]{8, 2, 23, 4, 24},
            new[]{21, 9, 14, 16, 7},
            new[]{6, 10, 3, 18, 5},
            new[]{1, 12, 20, 15, 19}
        },
        
        new []{
            new[]{3, 15, 0, 2, 22},
            new[]{9, 18, 13, 17, 5},
            new[]{19, 8, 7, 25, 23},
            new[]{20, 11, 10, 24, 4},
            new[]{14, 21, 16, 12, 6}
        },

        new []{
            new[]{14, 21, 17, 24, 4},
            new[]{10, 16, 15, 9, 19},
            new[]{18, 8, 23, 26, 20},
            new[]{22, 11, 13, 6, 5},
            new[]{2, 0, 12, 3, 7}
        }};
        
        [Fact]
        public void DrawUntilOneBoardHasNotWon_ShouldReturnCorrectBoard()
        {
            // arrange
            const int expectedBoardScore = 1924;
            var boards = Boards.Select(it => new BingoBoard(it)).ToList();

            // act
            var (winnerBoard, winningNum) = Day04Common.DrawUntilOneBoardHasNotWon(DrawnNumbers, boards);
            var actualScore = winnerBoard.CalculateScore(winningNum);
                
            // assert
            actualScore.Should().Be(expectedBoardScore);
        }
        
    }
}