using GameSubNumber.ClassHelpers;
using GameSubNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GameSubNumber
{
    class Program
    {
        private static int Players = 1;
        private static int Round = 0;
        private static int PlayerMove = 0;
        private static int Number = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество игроков");
            Players = Convert.ToInt32(Console.ReadLine());
            IList<User> UsersList = new List<User>();
            for (int i = 0; i < Players; i++)
            {
                Console.WriteLine("Введите ник для 'Игрок{0}'", i + 1);
                User user = new User
                {
                    UserName = Console.ReadLine()
                };
                UsersList.Add(user);
            }
            //Console.WriteLine("Последовательность:");
            //foreach (User obj in UsersList)
            //    Console.WriteLine(obj.UserName);
            Number = ProgramClassHelper.Number;
            Console.WriteLine("Сгенерированное число: "+ Number);
            while (Number > 0)
            {
                if (PlayerMove < UsersList.Count - 1)
                    PlayerMove++;
                else
                    PlayerMove = 0;
                Round++;
                Console.WriteLine("Раунд {0}. Ход игрока {1}", Round, UsersList[PlayerMove].UserName);
                Console.WriteLine("Введите число");
                Number = Number - Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Игровое число равно: " + Number);
            } 
            Console.WriteLine("Игра окончена. Игрок " + UsersList[PlayerMove].UserName + " Одержал победу");
            Console.WriteLine("Игра закончена за {0} ходов", Round);
            Console.ReadLine();
        }
    }
}

