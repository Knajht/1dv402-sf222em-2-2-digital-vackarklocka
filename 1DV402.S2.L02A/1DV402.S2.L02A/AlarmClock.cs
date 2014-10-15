using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02A
{
    public class AlarmClock
    {
        #region Fields
        private int _hour;
        private int _minute;
        private int _alarmHour;
        private int _alarmMinute; 
        #endregion

        #region Properties
        public int Hour
        {
            get { return _hour; }
            set 
            { 
                if(value < 0 || value > 23)
                {
                    throw new ArgumentException("Timmen är inte i intervallet 0-23");
                }
                _hour = value;
            }
        }

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Minuten är inte i intervallet 0-59");
                }
                _minute = value;
            }
        }
        public int AlarmHour
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Alarmtimmen är inte i intervallet 0-23");
                }
                _alarmHour = value;
            }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Alarmminuten är inte i intervallet 0-59");
                }
                _alarmMinute = value;
            }
        } 
        #endregion

        #region Constructors
        public AlarmClock()
            : this(0, 0)
        {
            
        }
        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {

        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Increases the time by one minute per call, checks if the alarm goes off
        /// </summary>
        /// <returns></returns>
        public bool TickTock()
        {
            bool alarm = false;
            
            //Increases time by 1 minute, compensates for new hour and day
            if(Minute == 59)
            {
                Minute = 0;
                if(Hour == 23)
                {
                    Hour = 0;
                }
                else
                {
                    Hour++;
                }
            }
            else
            {
                Minute++;
            }

            //Checks if the alarm goes off
            if(Hour == AlarmHour && Minute == AlarmMinute)
            {
                alarm = true;
            }
            return alarm;
        }

        /// <summary>
        /// Formats the current time and alarm time to a string that is returned
        /// </summary>
        public string ToString()
        {
            string time = string.Format("{0, 2}:{1:D2} ({2}:{3:D2})", Hour, Minute, AlarmHour, AlarmMinute);
            return time;
        } 
        #endregion
    }
}
