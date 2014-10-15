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
                    throw new ArgumentException();
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
                    throw new ArgumentException();
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
                    throw new ArgumentException();
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
                    throw new ArgumentException();
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

        } 
        #endregion

        #region Methods
        public bool TickTock()
        {
            throw new NotImplementedException();
        }

        public string ToString()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
