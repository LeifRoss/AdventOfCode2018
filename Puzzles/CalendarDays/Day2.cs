using Puzzles.Models.Interfaces;
using System.Linq;

namespace Puzzles.CalendarDays
{
    public class Day2 : ICalendarDay
    {
        public string RunFirstPart(string input)
        {
            int matchTwo = 0, matchThree = 0;

            input
                .Split('\n')
                .ToList()
                .ForEach(
                    code =>
                    {
                        var counts = code
                            .ToCharArray()
                            .GroupBy(c => c)
                            .Select(c => c.Count());

                        matchTwo += counts.Any(c => c == 2) ? 1 : 0;
                        matchThree += counts.Any(c => c == 3) ? 1 : 0;
                    }
                );

            return $"{matchTwo * matchThree}";
        }

        public string RunSecondPart(string input)
        {
            var codes = input.Split('\n').Select(code => code.Trim().ToCharArray());

            var choices = codes
                .Where(
                    a => codes.Any(
                        b => a.Where((c, idx) => c == b[idx]).Count() == b.Count() - 1
                    )
                )
                .ToList();

            return string.Join("", choices.First().Where((c, idx) => c == choices.Last()[idx]));
        }
    }
}
