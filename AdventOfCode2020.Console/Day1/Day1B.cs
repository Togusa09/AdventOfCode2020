using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Day1
{
    public class Day1B
    {
        private const int ExpectedSumTotal = 2020;

        public long SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day1A.txt");
            return Solve(fileContent);
        }

        public long Solve(string fileContent)
        {
            var numbers = fileContent.Split("\n", System.StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToHashSet();
            
            foreach(var number1 in numbers)
            {
                foreach (var number2 in numbers)
                {
                    var sumRemainder = ExpectedSumTotal - number1 - number2;
                    if (numbers.Contains(sumRemainder))
                    {
                        return sumRemainder * number1 * number2;
                    }
                }
            }


            return -1;
        }
    }
}
