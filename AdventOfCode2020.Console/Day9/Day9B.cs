using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.App.Day9
{
    public class Day9B : IAdventPuzzle<long>
    {
        public long Solve(string fileContent)
        {
            var invalidNumber = FindFirstInvalidNumber(fileContent, 25);
            return FindWeakness(fileContent, invalidNumber);
        }

        public long SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day9.txt");
            return Solve(fileContent);
        }

        public long FindWeakness(string input, long invalidNumber)
        {
            var lines = input
                .Replace("\r", "")
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; i < (lines.Length - i); j++)
                {
                    var sequence = lines.Skip(i).Take(j).ToArray();
                    var a = sequence.Sum();
                    if (a == invalidNumber)
                    {
                        var min = sequence.Min();
                        var max = sequence.Max();
                        return min + max;
                    }

                    if (a > invalidNumber) break;
                }
            }

            return -1;
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
