using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day2
{
    public class Day2B
    {
        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day2A.txt");
            return Solve(fileContent);
        }

        public int Solve(string fileContent)
        {
            var t = fileContent.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                

            return t.Count(ValidatePassword);
        }

        private bool ValidatePassword(string line)
        {
            var lineSegments = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bounds = lineSegments[0].Split("-").Select(x => int.Parse(x) - 1).ToArray();

            var character = lineSegments[1][0];
            var password = lineSegments[2];

            return (password[bounds[0]] == character && password[bounds[1]] != character)
                || (password[bounds[0]] != character && password[bounds[1]] == character);
        }
    }
}
