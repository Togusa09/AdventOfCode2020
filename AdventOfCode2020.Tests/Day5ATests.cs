using AdventOfCode2020.App.Day5;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day5ATests
    {
        [Theory]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        public void Test(string pass, int row, int column, int seatId)
        {
            var day5A = new Day5A();
            var result = day5A.CalculatePassId(pass);
            result.Should().Be(seatId);
        }
    }
}
