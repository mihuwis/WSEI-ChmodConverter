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
            return "";
        }
    }
}
