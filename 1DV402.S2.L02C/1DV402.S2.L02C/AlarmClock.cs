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

        #region Properties
        /// <summary>
        /// Get formats the ClockDisplay[] _alarmTimes to string[] and returns it.
        /// </summary>
        public string[] AlarmTimes
        {
            get
            {
                string[] alarmTimes = new string[_alarmTimes.GetLength(0)];

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
                Array.Resize(ref _alarmTimes, value.GetLength(0));
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
            : this((String.Format("{0}:{1:D2}", hour, minute)), String.Format("{0}:{1:D2}", alarmHour, alarmMinute)) //Chose to call the next constructor here. Still, the ":D2" is a repetition just like the constructor in ClockDisplay.cs so it's far from perfect.
        {
        } 
        public AlarmClock(string time, params string[] alarmTimes)
        {
            _time = new ClockDisplay(time);
            _alarmTimes = new ClockDisplay[alarmTimes.GetLength(0)];
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

            foreach (ClockDisplay at in _alarmTimes)
            {
                if (at == _time)
                {
                    alarm = true;
                }
            }
            return alarm;
        }

        /// <summary>
        /// Returns the current time and alarm times as a string.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0} ({1})", _time.ToString(), String.Join(", ", AlarmTimes));
        }

        /// <summary>
        /// Checks if the calling object is equal to the specified object.
        /// </summary>
        public override bool Equals(object obj)
        {
            return ((obj != null) && (this.GetType() == obj.GetType()) && (this.GetHashCode() == obj.GetHashCode()));
        }

        /// <summary>
        /// Gets a hash code based on the text representation of this instance.
        /// </summary>
        public override int GetHashCode()
        {
            string hashSeed = this.ToString();
            return hashSeed.GetHashCode();
        }

        // Overloaded operators.
        public static bool operator ==(AlarmClock a, AlarmClock b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return (a.Equals(b));
        }
        public static bool operator !=(AlarmClock a, AlarmClock b)
        {
            return !(a == b);
        }
        #endregion
    }
}
