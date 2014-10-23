using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class Program
    {
        static string horizontalLine = new String('=', 80);

        static void Main(string[] args)
        {
//Tests to check class AlarmClock functionality
            //Test1
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.\n");
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac.ToString());

            //Test2
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar.\n");
            AlarmClock ac2 = new AlarmClock(9, 3);
            Console.WriteLine(ac2.ToString());

            //Test3
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar.\n");
            AlarmClock ac3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac3.ToString());

            //Test4
            ViewTestHeader("Test 4.\nTest av konstruktorn med minst två parametrar av typen string");
            AlarmClock ac4 = new AlarmClock("7:07", "7:10", "07:15", "07:20");
            Console.WriteLine(ac4.ToString());

            //Test5
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.\n");
            ac4.Time = "23:58";
            Run(ac4, 13);

            //Test6
            ViewTestHeader("Test 6.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden 6:15 samt låter den gå 6 minuter.\n");
            ac4.Time = "6:12";
            string[] alarmTimes = new string[] {"6:15", "6:17"}; //Can i do this in one line, without creating a temporary array?

            ac4.AlarmTimes = alarmTimes;
            Run(ac4, 6);

            //Test7
            ViewTestHeader("Test 7.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                ac4.Time = "43:09";
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                ac4.Time = "20:60";
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                alarmTimes = new string[] { "-1:19" };
                ac4.AlarmTimes = alarmTimes;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                alarmTimes = new string[] { "2:99" };
                ac4.AlarmTimes = alarmTimes;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }

            //Test8
            ViewTestHeader("Test 8.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                AlarmClock ac5 = new AlarmClock(41, 24, 7, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac6 = new AlarmClock(21, 78, 7, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac7 = new AlarmClock(21, 21, 31, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac8 = new AlarmClock(21, 21, 2, 139);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            catch (FormatException e)
            {
                ViewErrorMessage(e.Message);
            }
        }

        #region Methods
        /// <summary>
        /// Runs the specified AlarmClock object specified number of minutes, sets of alarm if need be.
        /// </summary>
        private static void Run(AlarmClock ac, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (ac.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("{0}   PIP, Pip, pip.... piiiip..", ac.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(ac.ToString());
                }
            }
        }

        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n{0}", message);
            Console.ResetColor();
        }

        private static void ViewTestHeader(string header)
        {
            Console.WriteLine("{0}{1}", horizontalLine, header);
        } 
        #endregion
    }
}
