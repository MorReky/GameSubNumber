using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSubNumber.ClassHelpers
{
   public static class ProgramClassHelper
    {
        public static int Number;
        static ProgramClassHelper()
        {
            Random random = new Random();
            ProgramClassHelper.Number = random.Next(12, 120);
        }
    }
}
