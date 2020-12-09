using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day4
{
    public class Day4A
    {
        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day4A.txt");
            return Solve(fileContent);
        }

        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' });

            var fields = new Dictionary<string, string>();
            var validPassports = 0;

            foreach(var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var keys = fields.Keys.Where(x => x != "cid").Count();
                    if (keys >= 7) validPassports++;

                    fields = new Dictionary<string, string>();

                    continue;
                }

                foreach(var data in line.Split(" "))
                {
                    var split = data.Split(":");
                    fields[split[0]] = split[1];
                }
            }

            return validPassports;
        }
    }
}
