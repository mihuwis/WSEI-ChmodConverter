using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodConverter
{
    public static class ChmodConverter
    {

        public static int SymbolicToNumeric(string symbolicValue)
        {
            if (symbolicValue == null)
            {
                throw new ArgumentException("Invalid lenght of argument. \n Argument needs to be 9 symbols long.");
            }
            int result = 0;
            for(int i = 0; i < 3; i++)
            {
                int sum = 0;
                if(symbolicValue[i * 3] == 'r') sum += 4;
                if(symbolicValue[i * 3 + 1] == 'w') sum += 2;
                if(symbolicValue[i * 3 + 2] == 'x') sum += 1;
                result = result * 10 + sum;
            }

            return result;
        }

        public static string NumericToSymbolic(int numericValue)
        {
            if (numericValue < 0 || numericValue > 777)
                throw new ArgumentOutOfRangeException("Numeric in range of 0 to 777");

            char[] symbolicValue = new char[9];
            int[] modes = { numericValue / 100, (numericValue / 10) % 10, numericValue % 10 };

            for (int i = 0; i < 3; i++)
            {
                int value = modes[i];
                symbolicValue[i * 3] = (value & 4) != 0 ? 'r' : '-';
                symbolicValue[i * 3 + 1] = (value & 2) != 0 ? 'w' : '-';
                symbolicValue[i * 3 + 2] = (value & 1) != 0 ? 'x' : '-';
            }

            return new string(symbolicValue);
        }
    }
}
