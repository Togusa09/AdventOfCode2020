using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Day9
{
    public class Day9A : IAdventPuzzle<long>
    {
        public long Solve(string fileContent)
        {
            return FindFirstInvalidNumber(fileContent, 25);
        }

        public long SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day9.txt");
            return Solve(fileContent);
        }

        public long FindFirstInvalidNumber(string input, int preambleSize)
        {
            var lines = input
                .Replace("\r", "")
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var preambleQueue = new Queue<long>(lines.Take(preambleSize));

            foreach(var line in lines.Skip(preambleSize))
            {
                var currentNumber = line;


                var isValid = preambleQueue.Select(x => currentNumber - x).Any(x => preambleQueue.Contains(x));

                if (!isValid)
                {
                    return currentNumber;
                }


                preambleQueue.Enqueue(line);
                while (preambleQueue.Count() > preambleSize) preambleQueue.Dequeue();
            }

            return -1;
        }
    }
}
