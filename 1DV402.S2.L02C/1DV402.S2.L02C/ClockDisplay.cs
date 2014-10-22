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
        public int Hour
        {
            get { return _hourDisplay.Number; }
            set { _hourDisplay.Number = value; }
        }
        public int Minute
        {
            get { return _minuteDisplay.Number; }
            set { _minuteDisplay.Number = value; }
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
        #endregion

        #region Methods
        /// <summary>
        /// Increases the time 1 minute, if the minute counter is reset (returns 0) it also increases the hours by 1.
        /// </summary>
        public void Increment()
        {
            _minuteDisplay.Increment();
            if (Minute == 0)
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

    }
}
