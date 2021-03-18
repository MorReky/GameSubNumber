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
        private static int Players=1;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество игроков");
            Players = Convert.ToInt32(Console.ReadLine());
            IList<User> UsersList = new List<User>();
            for (int i = 0; i < Players; i++)
            {
                Console.WriteLine("Введите ник для 'Игрок{0}'", i+1);
                User user = new User
                {
                    UserName = Console.ReadLine()
                };
                UsersList.Add(user);
            }
            Console.WriteLine("Последовательность:");
            foreach(User obj in UsersList)
            {
                Console.WriteLine(obj.UserName);
            }
            Console.ReadLine();
        }
    }
}

