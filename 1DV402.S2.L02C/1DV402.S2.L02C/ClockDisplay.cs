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
        /// <summary>
        /// Joint property for fields _hourDisplay and _minuteDisplay. Gets a string of the time, set checks the supplied string against a regular expression of the allowed times and sets if possible.
        /// </summary>
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
                    throw new FormatException(String.Format("The string '{0}' cannot be interpreted as a time in the format HH:mm.", value));
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
            :this(String.Format("{0}:{1:D2}", hour, minute)) //D2 should not be necessary, specified in class NumberDisplays overloaded method ToString(String s). But no instances of NumberDisplay is initiated. Hmm. Solve it with an interface perhaps? Some kind of shared resource needed.
        {
        } 
        public ClockDisplay(string time)
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
        #endregion
    }
}
