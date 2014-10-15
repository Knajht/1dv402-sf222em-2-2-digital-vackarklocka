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
            set { _hour = value; }
        }

        public int Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }
        public int AlarmHour
        {
            get { return _alarmHour; }
            set { _alarmHour = value; }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set { _alarmMinute = value; }
        } 
        #endregion


        #region Constructors
        public AlarmClock()
        {

        }
        public AlarmClock(int hour, int minute)
        {

        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {

        } 
        #endregion

        public bool TickTock()
        {
            throw new NotImplementedException();
        }

        public string ToString()
        {
            throw new NotImplementedException();
        }


    }
}
