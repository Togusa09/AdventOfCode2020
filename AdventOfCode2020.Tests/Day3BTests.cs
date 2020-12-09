using AdventOfCode2020.App.Day3;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{

    public class Day3BTests
    {
        [Fact]
        public void Test()
        {
            var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            var day3B = new Day3B();
            var result = day3B.Solve(input);
            result.Should().Be(336);
        }
    }
}
