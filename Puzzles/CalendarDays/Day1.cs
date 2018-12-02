using Puzzles.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.CalendarDays
{
    public class Day1 : ICalendarDay
    {
        public string RunFirstPart(string input)
        {
            return input
               .Split('\n')
               .Select(t => int.Parse(t))
               .Sum()
               .ToString();
        }

        public string RunSecondPart(string input)
        {
            int freq = 0, i = 0;
            var set = new HashSet<int> { freq };
            var delta = input.Split('\n').Select(t => int.Parse(t)).ToList();
            while (set.Add(freq += delta[i++ % delta.Count]));
            return freq.ToString();
        }
    }
}
