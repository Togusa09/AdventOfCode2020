using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.App.Day7
{
    public class Day7A : IAdventPuzzle<int>
    {
        Dictionary<string, List<(int Quantity, string Colour)>> _bagRules;

        public int Solve(string fileContent)
        {
            _bagRules = new Dictionary<string, List<(int Quantity, string Colour)>>();

            var lines = fileContent
.Replace("\r", "")
.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var a = line.Split(" bags contain ");
                var bagColour = a[0];
                var childBagTypes = a[1].Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToArray();

                if (!_bagRules.ContainsKey(bagColour))
                {
                    _bagRules[bagColour] = new List<(int Quantity, string Colour)>();
                }

                foreach (var childBag in childBagTypes)
                {
                    if (childBag != "no other bags")
                    {
                        var b = childBag.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var quantity = int.Parse(b[0]);
                        var colour = $"{b[1]} {b[2]}";

                        _bagRules[bagColour].Add((quantity, colour));
                    }

                }
            }

            var bagColours = _bagRules.Select(x => x.Key).Where(x => x != "shiny gold");

            var result = bagColours.Where(x => CanContain(x, "shiny gold")).ToArray();


            return result.Count();
        }

        bool CanContain(string outerBagColour, string innerBagColour)
        {
            if (!_bagRules.ContainsKey(outerBagColour) || !_bagRules[outerBagColour].Any()) return false;

            if (_bagRules[outerBagColour].Any(x => x.Quantity > 0 && x.Colour == innerBagColour)) return true;

            foreach(var bagColour in _bagRules[outerBagColour].Select(x => x.Colour))
            {
                var result = CanContain(bagColour, innerBagColour);
                if (result) return true;
            }

            return false;
        }

        public int SolveForFile()
        {
            var fileContent = File.ReadAllText(@"Input\Day7.txt");
            return Solve(fileContent);
        }
    }
}
