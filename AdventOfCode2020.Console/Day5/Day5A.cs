using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.App.Day5
{
    public class Day5A : IAdventPuzzle<int>
    {
        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return lines.Select(CalculatePassId).Max();
        }

        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day5.txt");
            return Solve(fileContent);
        }

        public int CalculatePassId(string pass)
        {
            var rowString = pass.Substring(0, 7);
            var columnString = pass.Substring(7);
            var row = CollapseRange((min: 0, max: 127), rowString);
            var column = CollapseRange((min: 0, max: 7), columnString);


            return row * 8 + column;
        }

        private int CollapseRange((int min, int max) possibleRange, string rowString)
        {
            for (var i = 0; i < rowString.Length; i++)
            {
                var rangeDiff = possibleRange.max - possibleRange.min;
                if (rowString[i] == 'F' || rowString[i] == 'L')
                {
                    possibleRange.max -= (rangeDiff + 1) / 2;
                }
                if (rowString[i] == 'B' || rowString[i] == 'R')
                {
                    possibleRange.min += (rangeDiff + 1) / 2;
                }
            }

            if (possibleRange.min != possibleRange.max) throw new Exception("Failed to partition range");

            return possibleRange.min;
        }

    }
}
