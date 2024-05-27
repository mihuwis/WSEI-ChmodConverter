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
            string user = symbolicValue.Substring(0, 2);
            string group = symbolicValue.Substring(3, 5);
            string others = symbolicValue.Substring(6);
            string[] rights = [user, group, others];
            int result = 0;
            foreach (string right in rights)
            {
                int sum = 0;
                if(right[0] == 'r') sum += 4;
                if(right[1] == 'w') sum += 2;
                if(right[2] == 'x') sum += 1;
            }

            return result;
        }

        public static string NumericToSymbolic(int numericValue)
        {
            return "";
        }
    }
}
