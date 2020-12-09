using AdventOfCode2020.App.Day2;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day2BTests
    {
        [Theory]
        [InlineData("1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc", 1)]
        void Test(string input, int expectedResult)
        {
            var day2B = new Day2B();
            var result = day2B.Solve(input);
            result.Should().Be(expectedResult);
        }
    }
}
