using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.App.Day4
{
    public class Day4B
    {
        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day4A.txt");
            return Solve(fileContent);
        }

        private Dictionary<string, Func<string, bool>> _validationRules = new Dictionary<string, Func<string, bool>>
        {
            { "byr", (s) => Between(s, 1920, 2002) },
            { "iyr", (s) => Between(s, 2010, 2020) },
            { "eyr", (s) => Between(s, 2020, 2030) },
            { "hgt", (s) => ValidHeight(s) },
            { "hcl", (s) => IsHexColour(s) },
            { "ecl", (s) => IsEyeColour(s) },
            { "pid", (s) => IsPassportNum(s) },
            { "cid", (s) => true },
        };

        private static bool Between(string s, int min, int max)
        {
            var val = int.Parse(s);
            return min <= val && val <= max;
        }

        private static bool ValidHeight(string s)
        {
            var numPart = s.Replace("cm", "").Replace("in", "");
            if (s.Contains("cm")) return Between(numPart, 150, 193);
            if (s.Contains("in")) return Between(numPart, 59, 76);
            return false;
        }

        private static bool IsEyeColour(string s)
        {
            return new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(s);
        }

        private static bool IsHexColour(string s)
        {
            return s[0] == '#' && s.Substring(1).All(c => char.IsDigit(c) || (c >= 'a' && c <= 'f'));
        }

        private static bool IsPassportNum(string s)
        {
            return s.All(c => Char.IsDigit(c)) && s.Length == 9;
        }

        public int Solve(string fileContent)
        {
            var lines = fileContent
                .Replace("\r", "")
                .Split(new char[] { '\n' });

            var fields = new Dictionary<string, string>();
            var validPassports = 0;

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    foreach (var data in line.Split(" "))
                    {
                        var split = data.Split(":");
                        fields[split[0]] = split[1];
                    }
                }
                
                if (string.IsNullOrWhiteSpace(line) || line == lines.Last())
                {
                    var keys = fields.Where(x => x.Key != "cid")
                        .Select(x => new { x.Key, IsValid = _validationRules[x.Key](x.Value) })
                        .ToArray();
                    if (keys.Count(x => x.IsValid) >= 7) validPassports++;

                    fields = new Dictionary<string, string>();

                    continue;
                }
            }

            return validPassports;
        }
    }
}
