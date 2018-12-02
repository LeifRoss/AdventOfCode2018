using System;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new AdventCalendar();
            calendar.RunAll();
            Console.WriteLine("Press Enter to finish..");
            Console.ReadLine();
        }
    }
}
