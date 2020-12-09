using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day2
{
    public class Day2A
    {
        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day2A.txt");
            return Solve(fileContent);
        }

        public int Solve(string fileContent)
        {
            var t = fileContent.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Count(ValidatePassword);

            return t;
        }

        private bool ValidatePassword(string line)
        {
            var lineSegments = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bounds = lineSegments[0].Split("-").Select(int.Parse).ToArray();

            var character = lineSegments[1][0];
            var password = lineSegments[2];

            var characterCount = password.Count(x => x == character);
            return bounds[0] <= characterCount && characterCount <= bounds[1];
        }
    }
}
