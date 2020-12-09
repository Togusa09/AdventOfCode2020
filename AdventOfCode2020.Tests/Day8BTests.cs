using AdventOfCode2020.App.Day8;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{

    public class Day8BTests
    {
        [Fact]
        public void Test()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            var day8B = new Day8B();
            var result = day8B.Solve(input);
            result.Should().Be(8);
        }
    }
}
