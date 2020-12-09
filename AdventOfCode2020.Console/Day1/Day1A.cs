using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Day1
{
    public class Day1A : IAdventPuzzle<int>
    {
        private const int ExpectedSumTotal = 2020;

        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day1A.txt");
            return Solve(fileContent);
        }

        public int Solve(string fileContent)
        {
            var numbers = fileContent.Split("\n", System.StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToHashSet();

            foreach (var number in numbers)
            {
                var sumRemainder = ExpectedSumTotal - number;
                if (numbers.Contains(sumRemainder))
                {
                    return sumRemainder * number;
                }
            }

            return -1;
        }
    }
}
