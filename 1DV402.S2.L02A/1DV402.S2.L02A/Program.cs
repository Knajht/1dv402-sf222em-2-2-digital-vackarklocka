﻿using System;
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
//Tests to check class AlarmClock functionality
            //Test1
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.\n");
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac.ToString());

            //Test2
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar.\n");
            AlarmClock ac2 = new AlarmClock(9, 42);
            Console.WriteLine(ac2.ToString());

            //Test3
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar.\n");
            AlarmClock ac3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac3.ToString());

            //Test4
            ViewTestHeader("Test 4.\nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.\n");
            ac3.Hour = 23;
            ac3.Minute = 58;
            for (int i = 0; i < 13; i++)
            {
                ac3.TickTock();
                Console.WriteLine(ac3.ToString());
            }

            //Test5
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden 6:15 samt låter den gå 6 minuter.\n");
            ac3.Hour = 6;
            ac3.Minute = 13;
            ac3.AlarmHour = 6;
            ac3.AlarmMinute = 15;
            for (int i = 0; i < 6; i++)
            {
                if (ac3.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("{0}   PIP, Pip, pip.... piiiip..", ac3.ToString());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(ac3.ToString());
                }
            }

            //Test6
//Här börjar det bli knepigt. Måste lära mig mer om Exeptions så jag vet hur jag kan hantera sånt här snyggare.
            ViewTestHeader("Test 6.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                ac3.Hour = 43;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                ac3.Minute = 60;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                ac3.AlarmHour = -1;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                ac3.AlarmMinute = -20;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }

            //Test7
//Även detta test fult, om än funktionellt. Hur fångar jag flera exeptions?
            ViewTestHeader("Test 7.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                AlarmClock ac4 = new AlarmClock(41, 24, 7, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac4 = new AlarmClock(21, 78, 7, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac4 = new AlarmClock(21, 21, 31, 35);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock ac4 = new AlarmClock(21, 21, 2, 139);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
        }

        #region OtherMethods
        private static void Run(AlarmClock ac, int minutes)
        {
            ac.Minute = ac.Minute + minutes;
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
