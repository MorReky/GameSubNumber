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
        private static string Сommand;
        private static string InPut;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!");
            while (true)
            {
                Console.WriteLine("Для настройки игры введите 'Настройка'");
                Console.WriteLine("Для старта введите 'Старт'");
                Console.WriteLine("Для выхода введите 'Выход'");
                Сommand = Console.ReadLine();
                switch (Сommand)
                {
                    case "Настройка":
                        {
                            Console.WriteLine("Для выбора сложности выберите соответствующее число, обозначающее уровень");
                            Console.WriteLine("1:Ввод чисел от 1-4");
                            Console.WriteLine("2:Ввод чисел от 1-3");
                            Console.WriteLine("3:Ввод чисел от 1-2");
                            InPut = Console.ReadLine();
                            if (Convert.ToInt32(InPut) == 1 || Convert.ToInt32(InPut) == 2 || Convert.ToInt32(InPut) == 3)
                            {
                                DataValidation.Level = Convert.ToInt32(InPut);
                                Console.WriteLine("Сложность обновлена");
                            }
                            else
                                Сommand = InPut;
                            break;
                        }
                    case "Старт":
                        {
                            Console.WriteLine("Действует следующее правило:" + DataValidation.Level);
                            Console.WriteLine("Введите количество игроков. Для игры с компьютером введите '1'");
                            Players = Convert.ToInt32(Console.ReadLine());
                            IList<User> UsersList = new List<User>();
                            if (Players > 1)
                            {
                                for (int i = 0; i < Players; i++)
                                {
                                    Console.WriteLine("Введите ник для 'Игрок{0}'", i + 1);
                                    User user = new User
                                    {
                                        UserName = Console.ReadLine()
                                    };
                                    UsersList.Add(user);
                                }
                            }
                            if (Players == 1)
                            {
                                Console.WriteLine("Введите ник для 'Игрокa 1'");
                                User user = new User
                                {
                                    UserName = Console.ReadLine()
                                };
                                UsersList.Add(user);
                                User Computer = new User
                                {
                                    UserName = "Компьютер",
                                    Flag = 1
                                };
                                UsersList.Add(Computer);
                            }

                            Number = ProgramClassHelper.Number;
                            Console.WriteLine("Сгенерированное число: " + Number);
                            while (Number > 0)
                            {
                                if (PlayerMove < UsersList.Count - 1)
                                    PlayerMove++;
                                else
                                    PlayerMove = 0;
                                Round++;
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("Раунд {0}. Ход игрока {1}", Round, UsersList[PlayerMove].UserName);
                                if (UsersList[PlayerMove].Flag == 0)
                                {
                                    Console.WriteLine("Введите число");
                                    InPut = Console.ReadLine();
                                }
                                else
                                {
                                    InPut = Convert.ToString(ComputerStep.Step());
                                }
                                if (!DataValidation.Validation(InPut))
                                {
                                    do
                                    {
                                        Console.WriteLine("Вы указали некорректное число");
                                        Console.WriteLine("Введите число");
                                        InPut = Console.ReadLine();
                                    }
                                    while (!DataValidation.Validation(InPut));
                                }
                                Number = Number - Convert.ToInt32(InPut);
                                Console.WriteLine("Игровое число равно: " + Number);
                            }
                            Console.WriteLine("Игра окончена. Игрок " + UsersList[PlayerMove].UserName + " Одержал победу");
                            Console.WriteLine("Игра закончена за {0} ходов", Round);
                            Console.ReadLine();
                            Console.WriteLine("Для настройки игры введите 'Настройка'");
                            Console.WriteLine("Для старта введите 'Старт'");
                            Console.WriteLine("Для выхода введите 'Выход'");
                            break;
                        }
                    case "Выход":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введенная комманда не обнаружена");
                            break;
                        }
                }
            }
        }
    }
}
