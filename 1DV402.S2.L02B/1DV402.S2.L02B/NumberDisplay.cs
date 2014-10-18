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

        public int MaxNumber
        {
            get { return _maxNumber; }
            set { _maxNumber = value; }
        }
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }


    }
}
