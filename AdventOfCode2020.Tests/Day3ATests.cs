using AdventOfCode2020.App.Day3;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2020.Tests
{

    public class Day3ATests
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

            var day3A = new Day3A();
            var result = day3A.Solve(input);
            result.Should().Be(7);
        }
    }
}
