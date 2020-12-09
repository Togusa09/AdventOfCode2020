using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using AdventOfCode2020.App.Day6;

namespace AdventOfCode2020.Tests
{
    public class Day6ATests
    {
        [Fact]
        public void TestSingleGroup()
        {
            var input = @"abcx
abcy
abcz";

            var day6A = new Day6A();
            var result = day6A.Solve(input);
            result.Should().Be(6);
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

            var day6A = new Day6A();
            var result = day6A.Solve(input);
            result.Should().Be(11);
        }
    }
}
