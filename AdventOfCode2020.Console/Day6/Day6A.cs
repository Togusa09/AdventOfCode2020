using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day6
{
    public class Day6A : IAdventPuzzle<int>
    {
        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' });

            List<char> answers = new List<char>();
            var total = 0;

            foreach(var line in lines)
            {
                answers.AddRange(line.ToArray());


                if (string.IsNullOrEmpty(line) || line == lines.Last())
                {
                    var distinctChars = answers.Distinct().Count();
                    total += distinctChars;
                    answers = new List<char>();   
                }
            }

            return total;
        }

        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day6.txt");
            return Solve(fileContent);
        }
    }
}
