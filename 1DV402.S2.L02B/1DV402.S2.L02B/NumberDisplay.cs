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


        //TODO: Egenskaperna ska validera!
        public int MaxNumber
        {
            get { return _maxNumber; }
            set { _maxNumber = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public NumberDisplay(int maxNumber)
            :this(maxNumber, 0)
        {
        }
        //TODO: Denna ska initiera objektet
        public NumberDisplay(int maxNumber, int number)
        {

        }

        public void Increment()
        {

        }

        public string ToString()
        {
            throw new NotImplementedException();
        }

        public string ToString(string format)
        {
            throw new NotImplementedException();
        }


    }
}
