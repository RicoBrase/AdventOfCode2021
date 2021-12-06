using AdventOfCode._2021.Day06;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day06
{
    public class LanternfishTests
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void LanternfishCtor_ShouldInitializeTimerCorrectly(int expectedInitialState)
        {
            // arrange
            
            // act
            var lanternFish = new Lanternfish(expectedInitialState);

            // assert
            lanternFish.Timer.Should().Be(expectedInitialState);
        }

        [Fact]
        public void Tick_ShouldSpawnNewLanternfish_IfTimerHitsZero()
        {
            // arrange
            var fish = new Lanternfish(1);
            
            // act
            var tick1Result = fish.Tick();
            var tick2Result = fish.Tick();

            // assert
            tick1Result.Should().BeNull();
            fish.Timer.Should().Be(Lanternfish.RESET_TIMER_TO);
            tick2Result.Should().NotBeNull();
            tick2Result.Timer.Should().Be(Lanternfish.INIT_TIMER_NEW_SPAWN);
        }
        
    }
}