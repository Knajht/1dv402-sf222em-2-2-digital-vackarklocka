using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    public class AlarmClock
    {
        #region Fields
        //Aggregates
        private ClockDisplay[] _alarmTimes;
        private ClockDisplay _time; 
        #endregion

        //#region Properties
        //public int AlarmHour
        //{
        //    get { return _alarmTime.Hour; }
        //    set { _alarmTime.Hour = value; }
        //}
        //public int AlarmMinute
        //{
        //    get { return _alarmTime.Minute; }
        //    set { _alarmTime.Minute = value; }
        //}
        //public int Hour
        //{
        //    get { return _time.Hour; }
        //    set { _time.Hour = value; }
        //}
        //public int Minute
        //{
        //    get { return _time.Minute; }
        //    set { _time.Minute = value; }
        //} 
        //#endregion

        public string[] AlarmTimes
        {
            get
            {
                string[] alarmTimes = new string[2];

                int i = 0;
                foreach (ClockDisplay at in _alarmTimes)
                {
		            alarmTimes[i] = at.ToString();
                    i++;
                }
                return alarmTimes;
            }
            set
            {
                int i = 0;
                foreach (string at in value)
                {
                    ClockDisplay alarm = new ClockDisplay(at);
                    _alarmTimes[i] = alarm;
                    i++;
                }
            }
        }

        public string Time
        {
            get
            {
                return _time.Time;
            }
            set
            {
                _time.Time = value;
            }
        }

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
            _alarmTimes = new ClockDisplay[2];
            _alarmTimes[0] = new ClockDisplay(alarmHour, alarmMinute);
        } 
        //NEW CONSTRUCTOR - Initiate array?
        public AlarmClock(string time, params string[] alarmTimes)
        {
            _time = new ClockDisplay(time);
            _alarmTimes = new ClockDisplay[0];
            AlarmTimes = alarmTimes;
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

            foreach (ClockDisplay at in _alarmTimes) //Change to string & use properties instead?
            {
                if (at == _time)
                {
                    alarm = true;
                }
            }
            return alarm;
        }

        /// <summary>
        /// Returns the current time and alarm time as a string.
        /// </summary>
        public override string ToString()
        {
            string alarmTimes = null;
            foreach (string at in AlarmTimes)
            {
                alarmTimes = String.Format("{0} {1}", alarmTimes, at); //How does this work if it's only one alarmtime? TODO Solve separation
            }
            return String.Format("{0} ({1})", _time.ToString(), alarmTimes.ToString());
        } 
        #endregion
    }
}
