using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSubNumber.ClassHelpers
{
    /// <summary>
    /// Вспомогательный класс для генерации игрового числа
    /// </summary>
   internal static class ProgramClassHelper
    {
        public static int Number;
        static ProgramClassHelper()
        {
            Random random = new Random();
            Number = random.Next(12, 121);
        }
    }
}
