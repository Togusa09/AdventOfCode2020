using AdventOfCode2020.App.Day1;
using FluentAssertions;
using System;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day1ATests
    {
        [Theory]
        [InlineData("1721\n979\n366\n299\n675\n1456", 514579)]
        public void CalculatesAnswer(string fileInput, int expectedAnswer)
        {
            var day1A = new Day1A();
            var result = day1A.Solve(fileInput);
            result.Should().Be(expectedAnswer);
        }
    }
}
