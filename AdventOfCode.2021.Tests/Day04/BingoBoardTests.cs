using System.Linq;
using AdventOfCode._2021.Day04;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day04
{
    public class BingoBoardTests
    {
        private static readonly int[] DrawnNumbers =
            {7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1};

        private static int[][] Board1 => new [] {
            new[]{22, 13, 17, 11, 0},
            new[]{8, 2, 23, 4, 24},
            new[]{21, 9, 14, 16, 7},
            new[]{6, 10, 3, 18, 5},
            new[]{1, 12, 20, 15, 19}
        };
        
        private static readonly int[][] Board2 = {
            new[]{3, 15, 0, 2, 22},
            new[]{9, 18, 13, 17, 5},
            new[]{19, 8, 7, 25, 23},
            new[]{20, 11, 10, 24, 4},
            new[]{14, 21, 16, 12, 6}
        };

        private static readonly int[][] Board3 = {
            new[]{14, 21, 17, 24, 4},
            new[]{10, 16, 15, 9, 19},
            new[]{18, 8, 23, 26, 20},
            new[]{22, 11, 13, 6, 5},
            new[]{2, 0, 12, 3, 7}
        };

        [Fact]
        public void GetFieldDataAt_ShouldReturnCorrectData()
        {
            // arrange
            var bingo1 = new BingoBoard(Board1);
            var bingo2 = new BingoBoard(Board2);
            var bingo3 = new BingoBoard(Board3);

            // act
            // assert
            for (var y = 0; y < Board1.Length; y++)
            {
                for (var x = 0; x < Board1[y].Length; x++)
                {
                    bingo1.GetFieldDataAt(x, y).num.Should().Be(Board1[y][x]);
                    bingo2.GetFieldDataAt(x, y).num.Should().Be(Board2[y][x]);
                    bingo3.GetFieldDataAt(x, y).num.Should().Be(Board3[y][x]);
                }
            }
        }

        [Fact]
        public void DrawNumber_ShouldCorrectlyMarkTheField_IfItWasTheDrawnNumber()
        {
            // arrange
            var bingo = new BingoBoard(Board1);
            var beforeFieldData = bingo.GetFieldDataAt(2, 2);

            // act
            bingo.DrawNumber(14);
            var afterFieldData = bingo.GetFieldDataAt(2, 2);

            // assert
            beforeFieldData.num.Should().Be(14);
            beforeFieldData.marked.Should().Be(false);
            afterFieldData.num.Should().Be(14);
            afterFieldData.marked.Should().Be(true);
        }
        
        [Fact]
        public void DrawNumber_ShouldNotMarkTheField_IfItWasNotTheDrawnNumber()
        {
            // arrange
            var bingo = new BingoBoard(Board1);
            var beforeFieldData = bingo.GetFieldDataAt(2, 2);

            // act
            bingo.DrawNumber(15);
            var afterFieldData = bingo.GetFieldDataAt(2, 2);

            // assert
            beforeFieldData.num.Should().Be(14);
            beforeFieldData.marked.Should().Be(false);
            afterFieldData.num.Should().Be(14);
            afterFieldData.marked.Should().Be(false);
        }

        [Theory]
        [InlineData( new[]{22, 13, 17, 11, 0})]
        [InlineData( new[]{11, 4, 16, 18, 15})]
        public void DrawNumber_ShouldMarkBoardAsWon_IfWinConditionsAreTrue(int[] drawnNumbers)
        {
            // arrange
            var bingo = new BingoBoard(Board1);

            // act
            foreach (var num in drawnNumbers)
            {
                bingo.DrawNumber(num);
            }

            // assert
            bingo.Won.Should().BeTrue();
        }

        [Fact]
        public void GetAllUnmarked_ShouldReturnCorrectNumbers()
        {
            // arrange
            var expectedUnmarked = new[]{22, 13, 17, 11, 0, 8, 2, 23, 4, 24, 21, 9, 16, 7, 6, 10, 3, 18, 5, 1, 12, 20, 15, 19};
            var bingo = new BingoBoard(Board1);
            bingo.DrawNumber(14);
            
            // act
            var unmarked = bingo.GetAllUnmarked();

            // assert
            unmarked.Should().BeEquivalentTo(expectedUnmarked);
        }
        
        [Fact]
        public void GetAllMarked_ShouldReturnCorrectNumbers()
        {
            // arrange
            var expectedMarked = new[]{14};
            var bingo = new BingoBoard(Board1);
            bingo.DrawNumber(14);
            
            // act
            var marked = bingo.GetAllMarked();

            // assert
            marked.Should().BeEquivalentTo(expectedMarked);
        }

        [Fact]
        public void CalculateScore_ShouldCalculateCorrectScore()
        {
            // arrange
            const int expectedResult = 4512;
            var listOfBoards = new[] {Board1, Board2, Board3}.Select(it => new BingoBoard(it)).ToList();
            var (winningBoard, winningNumber) = Day04Common.DrawUntilOneBoardWins(DrawnNumbers, listOfBoards);

            // act
            var actualResult = winningBoard.CalculateScore(winningNumber);

            // assert
            actualResult.Should().Be(expectedResult);

        }
    }
}