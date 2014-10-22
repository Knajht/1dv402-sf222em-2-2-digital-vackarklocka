using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class ClockDisplay
    {
        #region Fields
        //Aggregates
        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay; 
        #endregion

        #region Properties
        //public int Hour
        //{
        //    get { return _hourDisplay.Number; }
        //    set { _hourDisplay.Number = value; }
        //}
        //public int Minute
        //{
        //    get { return _minuteDisplay.Number; }
        //    set { _minuteDisplay.Number = value; }
        //} 
        public string Time
        {
            get { return String.Format("{0}:{1}", _hourDisplay, _minuteDisplay); }
            set 
            {
                string sPattern = "^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$";
                if(System.Text.RegularExpressions.Regex.IsMatch(value, sPattern))
                {
                    //Since validation is already done with the Regex above, I use int.Parse without a try/catch clause.
                    string[] times;
                    times = value.Split(new char[] {':'});
                    _hourDisplay.Number = int.Parse(times[0]);
                    _minuteDisplay.Number = int.Parse(times[1]);
                }
                else
                {
                    throw new FormatException(); //Lägg till meddelande?
                }
            }            
        }
        #endregion

        #region Constructors
        public ClockDisplay()
            : this(0, 0)
        {
        }
        public ClockDisplay(int hour, int minute)
        {
            _hourDisplay = new NumberDisplay(23, hour);
            _minuteDisplay = new NumberDisplay(59, minute);
        } 
        public ClockDisplay(string time) //New, test it
        {
            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);
            Time = time;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Increases the time 1 minute, if the minute counter is reset (returns 0) it also increases the hours by 1.
        /// </summary>
        public void Increment()
        {
            _minuteDisplay.Increment();
            if (_minuteDisplay.Number == 0)
            {
                _hourDisplay.Increment();
            }
        }

        /// <summary>
        /// Returns a time string as HH:mm or H:mm
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}:{1}", _hourDisplay.ToString(), _minuteDisplay.ToString("00"));
        } 
        #endregion

// NEW METHODS
        public override bool Equals(object obj)
        {
            return ((obj != null) && (this.GetType() == obj.GetType()) && (this.GetHashCode() == obj.GetHashCode()));
        }

        //Beta, try it out
        public override int GetHashCode()
        {
            string hashSeed = this.ToString();
            return hashSeed.GetHashCode();
        }
        // Operators overloaded.
        public static bool operator ==(ClockDisplay a, ClockDisplay b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            return (a.Equals(b));
        }

        public static bool operator !=(ClockDisplay a, ClockDisplay b)
        {
            return !(a == b);
        }

    }
}
