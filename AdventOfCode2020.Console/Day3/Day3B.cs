using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day3
{
    public class Day3B
    {
        public long SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day3A.txt");
            return Solve(fileContent);
        }

        public long Solve(string fileContent)
        {
            var rows = fileContent.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var totalTrees = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }
                .Select(x => SolveSlope(rows, x))
                .Aggregate((long total, long x) => x * total);

            return totalTrees;
        }

        private long SolveSlope(string[] track, (int across, int down) slope)
        {
            var x = 0;
            var trees = 0;

            for(var i = 0; i < track.Length; i += slope.down)
            {
                var row = track[i];

                if (row[x] == '#') trees++;
                x = (x + slope.across) % row.Length;
            }

            return trees;
        }
    }
}
