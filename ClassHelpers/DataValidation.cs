using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameSubNumber.ClassHelpers
{
    internal static class DataValidation
    {
        public static int Level = 1;
        public static bool Validation(string s)
        {
            string pattern = "[1-4]";
            if (Level == 1)
                pattern = "[1-4]";
            if (Level == 2)
                pattern = "[1-3]";
            if (Level == 3)
                pattern = "[1-2]";


            if (Regex.IsMatch(s, pattern))
                return true;
            return false;

        }
    }
}
