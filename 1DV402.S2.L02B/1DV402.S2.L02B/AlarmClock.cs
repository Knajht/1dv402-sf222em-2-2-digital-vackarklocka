using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    public class AlarmClock
    {
        #region Fields
        //Aggregates
        private ClockDisplay _alarmTime;
        private ClockDisplay _time; 
        #endregion

        #region Properties
        public int AlarmHour
        {
            get { return _alarmTime.Hour; }
            set { _alarmTime.Hour = value; }
        }
        public int AlarmMinute
        {
            get { return _alarmTime.Minute; }
            set { _alarmTime.Minute = value; }
        }
        public int Hour
        {
            get { return _time.Hour; }
            set { _time.Hour = value; }
        }
        public int Minute
        {
            get { return _time.Minute; }
            set { _time.Minute = value; }
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
            _time = new ClockDisplay(hour, minute);
            _alarmTime = new ClockDisplay(alarmHour, alarmMinute);
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Increases the time by one minute per call, checks if the alarm goes off
        /// </summary>
        public bool TickTock()
        {
            bool alarm = false;
            _time.Increment();

            if (Hour == AlarmHour && Minute == AlarmMinute)
            {
                alarm = true;
            }
            return alarm;
        }

        /// <summary>
        /// Returns the current time and alarm time as a string.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0} ({1})", _time.ToString(), _alarmTime.ToString());
        } 
        #endregion
    }
}
