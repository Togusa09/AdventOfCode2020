using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using AdventOfCode2020.App.Day6;

namespace AdventOfCode2020.Tests
{
    public class Day6BTests
    {
        [Fact]
        public void TestSingleGroup()
        {
            var input = @"abcx
abcy
abcz";

            var day6B = new Day6B();
            var result = day6B.Solve(input);
            result.Should().Be(3);
        }

        [Fact]
        public void TestMultipleGroups()
        {
            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

            var day6B = new Day6B();
            var result = day6B.Solve(input);
            result.Should().Be(6);
        }
    }
}
