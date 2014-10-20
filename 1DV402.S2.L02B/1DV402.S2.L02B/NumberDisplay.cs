using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class NumberDisplay
    {
        private int _maxNumber;
        private int _number;


        //TODO: Meddelande?
        public int MaxNumber
        {
            get { return _maxNumber; }
            set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException(); //TODO: Skicka med meddelande?
                }
                _maxNumber = value; 
            }
        }

        public int Number
        {
            get { return _number; }
            set 
            {
                if(value <= 0 || value > MaxNumber)
                {
                    throw new ArgumentException(); //TODO: Skicka med meddelande?
                }
                
                _number = value; 
            }
        }

        public NumberDisplay(int maxNumber)
            :this(maxNumber, 0)
        {
        }
        //READY - Konstruktorer
        public NumberDisplay(int maxNumber, int number)
        {
            MaxNumber = maxNumber;
            Number = number;
        }

        public void Increment()
        {
            Number++;
            if(Number > MaxNumber)
            {
                Number = 0;
            }
        }

        public string ToString()
        {
            //return String.Format("{0}", Number);
            return ToString("0"); //TODO: Välja metod.
        }

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
                    throw new FormatException();//TODO: Meddelande?
            }
        }
    }
}
