using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02A
{
    class Program
    {
        static string horizontalLine = new String('=', 80);

        static void Main(string[] args)
        {
            
            //Console.WriteLine(HorizontalLine);
        }
        private static void Run(AlarmClock ac, int minutes)
        {
            ac.Minute = ac.Minute + minutes;
        }

        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ViewTestHeader(string header)
        {
            Console.WriteLine("{0}\n{1}", horizontalLine, header);
        }
    }
}
