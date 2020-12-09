using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.App.Day8
{
    public class Day8A : IAdventPuzzle<int>
    {
        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var instructionPointer = 0;
            var accumulator = 0;

            var executedCommands = new List<int>();

            while (true)
            {
                var line = lines[instructionPointer];
                var a = line.Split(' ');
                var command = a[0];
                var value = int.Parse(a[1]);

                if (executedCommands.Contains(instructionPointer)) break;
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

            return accumulator;
        }


        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day8.txt");
            return Solve(fileContent);
        }
    }
}
