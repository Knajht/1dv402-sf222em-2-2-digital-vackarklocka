using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class NumberDisplay
    {
        #region Fields
        private int _maxNumber;
        private int _number; 
        #endregion

        #region Properties
        public int MaxNumber
        {
            get { return _maxNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid MaxNumber, needs to be over 0");
                }
                _maxNumber = value;
            }
        }

        public int Number
        {
            get { return _number; }
            set
            {
                if (value < 0 || value > MaxNumber)
                {
                    throw new ArgumentException(String.Format("The number needs to be in the interval between 0 and {0}", MaxNumber));
                }
                _number = value;
            }
        } 
        #endregion

        #region Constructor
        public NumberDisplay(int maxNumber)
            : this(maxNumber, 0)
        {
        }
        public NumberDisplay(int maxNumber, int number)
        {
            MaxNumber = maxNumber;
            Number = number;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Increases Number by 1, unless it would pass the MaxNumber, in which case it sets Number to 0.
        /// </summary>
        public void Increment()
        {
            if (Number == MaxNumber)
            {
                Number = 0;
            }
            else
            {
                Number++;
            }
        }
        /// <summary>
        /// Returns the Number without zero padding
        /// </summary>
        public override string ToString()
        {
            return ToString("0");
        }
        
        /// <summary>
        /// Returns the Number in specified format, "00" as a two-digit number.
        /// </summary>
        public string ToString(string format)
        {
            switch (format)
            {
                case "0":
                case "G":
                    return String.Format("{0}", Number);
                case "00":
                    return String.Format("{0:D2}", Number);
                default:
                    throw new FormatException("This is not a known format for Number.");
            }
        } 
        #endregion
    }
}
