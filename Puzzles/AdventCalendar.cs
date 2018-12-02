using Puzzles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Puzzles
{
    public class AdventCalendar
    {
        private Dictionary<int, ICalendarDay> _calendarDays;
        
        public AdventCalendar()
        {
            _calendarDays = new Dictionary<int, ICalendarDay>();
            Init();
        }

        private void Init()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == "Puzzles.CalendarDays" && t.IsVisible)
                .ToList()
                .ForEach(t => Add(t));
        }
        
        public void RunAll()
        {
            foreach (int day in _calendarDays.Keys)
                Run(day);
        }

        public void RunToday()
        {
            Run(DateTime.UtcNow.Day);
        }

        public void Run(int day)
        {
            string path = $@"Input\\day{day}.txt";
            string input = File.Exists(path) ? File.ReadAllText(path) : "";
            Run(day, input);
        }

        public void Run(int day, string input)
        {
            if (!HasBeenSolved(day))
            {
                Console.WriteLine($"Day {day} has not been solved!");
                return;
            }
            
            ICalendarDay solution = Get(day);

            Console.WriteLine($"Day: {day}");
            Console.WriteLine($"First Task: {solution.RunFirstPart(input)}");
            Console.WriteLine($"Second Task: {solution.RunSecondPart(input)}\n");
        }

        public bool HasBeenSolved(int day)
        {
            return _calendarDays.ContainsKey(day);
        }
        
        public ICalendarDay Get(int day)
        {
            return _calendarDays[day];
        }

        private void Add(Type t)
        {
            Add(int.Parse(t.Name.Substring(3)), (ICalendarDay)Activator.CreateInstance(t));
        }

        private void Add(int day, ICalendarDay solution)
        {
            _calendarDays.Add(day, solution);
        }
    }
}
