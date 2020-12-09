using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Day6
{
    public class Day6B : IAdventPuzzle<int>
    {
        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' });

            List<char[]> answers = new List<char[]>();
            var total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    answers.Add(line.ToArray());
                }

                if (string.IsNullOrEmpty(line) || i == (lines.Length - 1))
                {
                    var answerCount = answers.Count();
                    var a = answers.SelectMany(answerSet => answerSet).ToList();
                    var b = a.GroupBy(answer => answer);
                    var c = b.Where(groupedAnswers => groupedAnswers.Count() == answerCount);
                    var d = c.Select(groupedAnswers => groupedAnswers.Key);
                    var distinctChars =   d.Count();
                    total += distinctChars;
                    answers.Clear();
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
