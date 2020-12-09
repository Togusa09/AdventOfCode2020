using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.App.Day3
{
    public class Day3A
    {
        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day3A.txt");
            return Solve(fileContent);
        }

        public int Solve(string fileContent)
        {
            var rows = fileContent.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var x = 0;
            var trees = 0;
            foreach (var row in rows)
            {
                if (row[x] == '#') trees++;
                x = (x + 3) % row.Length;
            }

            return trees;
        }
    }
}
