using AdventOfCode2020.App.Day9;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day9ATests
    {
        [Fact]
        public void Test()
        {
            var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

            var day9A = new Day9A();
            var result = day9A.FindFirstInvalidNumber(input, 5);
            result.Should().Be(127);
        }
    }
}
