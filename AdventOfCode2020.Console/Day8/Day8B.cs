using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day8
{
    public class Day8B : IAdventPuzzle<int>
    {
        Dictionary<string, List<(int Quantity, string Colour)>> _bagRules;

        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                var tempProgram = lines.Select(x => x).ToArray();

                if (lines[i].StartsWith("nop"))
                {
                    tempProgram[i] = lines[i].Replace("nop", "jmp");
                }

                if (lines[i].StartsWith("jmp"))
                {
                    tempProgram[i] = lines[i].Replace("jmp", "nop");
                }

                var result = RunProgram(tempProgram);
                if (result.completed) { return result.value; }
            }

            return -1;
        }

        private static (bool completed, int value) RunProgram(string[] lines)
        {
            var instructionPointer = 0;
            var accumulator = 0;

            var executedCommands = new List<int>();

            while (instructionPointer < lines.Length)
            {
                var line = lines[instructionPointer];
                var a = line.Split(' ');
                var command = a[0];
                var value = int.Parse(a[1]);

                if (executedCommands.Contains(instructionPointer)) return (false, accumulator);
                executedCommands.Add(instructionPointer);

                switch (command)
                {
                    case "nop":
                        instructionPointer++;
                        break;
                    case "acc":
                        accumulator += value;
                        instructionPointer++;
                        break;
                    case "jmp":
                        instructionPointer += value;
                        break;
                }
            }

            return (true, accumulator);
        }

        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day8.txt");
            return Solve(fileContent);
        }
    }
}
