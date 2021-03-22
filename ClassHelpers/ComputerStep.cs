using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSubNumber.ClassHelpers
{
    /// <summary>
    /// Вспомогательный класс, симулирующий ход компьютера
    /// </summary>
    internal static class ComputerStep
    {
        public static int Step()
        {
            Random random = new Random();
            
            switch (DataValidation.Level)
            {
                case 1: return random.Next(1, 4); 
                case 2: return random.Next(1, 3); 
                case 3: return random.Next(1, 2);
                default: return 0;
            }
        }
    }
}
