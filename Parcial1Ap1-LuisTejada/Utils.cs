using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_LuisTejada
{
    public class Utils
    {
        public static bool NoWhiteNoSpace(string text)
        {
            if(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
