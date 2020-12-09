using AdventOfCode2020.App.Day2;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day2ATests
    {
        [Theory]
        [InlineData("1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc", 2)]
        void Test(string input, int expectedResult)
        {
            var day2A = new Day2A();
            var result = day2A.Solve(input);
            result.Should().Be(expectedResult);
        }
    }
}
