using AdventOfCode2020.App.Day9;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day9BTests
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

            var day9B = new Day9B();
            var result = day9B.FindWeakness(input, 127);
            result.Should().Be(62);
        }
    }
}
