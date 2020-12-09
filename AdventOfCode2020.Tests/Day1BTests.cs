using AdventOfCode2020.App.Day1;
using FluentAssertions;
using System;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day1BTests
    {
        [Theory]
        [InlineData("1721\n979\n366\n299\n675\n1456", 241861950)]
        public void CalculatesAnswer(string fileInput, long expectedAnswer)
        {
            var day1A = new Day1B();
            var result = day1A.Solve(fileInput);
            result.Should().Be(expectedAnswer);
        }
    }
}
