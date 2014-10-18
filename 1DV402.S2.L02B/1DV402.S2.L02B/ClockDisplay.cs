using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class ClockDisplay
    {
        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay;

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

        public ClockDisplay()
            :this(0, 0)
        {
        }
        //TODO: Denna ska initiera!
        public ClockDisplay(int hour, int minute)
        {

        }

        public void Increment()
        {

        }

        public string ToString()
        {
            throw new NotImplementedException();
        }

    }
}
