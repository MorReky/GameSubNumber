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
        public static bool Validation(string s)
        {
            string pattern = "[1-4]";

            if (Regex.IsMatch(s, pattern))
                return true;
            return false;

        }
    }
}
