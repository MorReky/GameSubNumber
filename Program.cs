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
        private static uint Players = 1;
        private static int Round = 0;
        private static int PlayerMove = 0;
        private static int Number = 0;
        private static string Сommand;
        private static string userTry;
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Правила этой игры просты.\n Компьютер выбирает случайное число в диапазоне 12-120. Задача каждого игрока первым привести это число к 0.\n Каким образом? Все также очень просто. Игроки совершают свой ход по очереди вводя числа в определенном диапазоне. Этот диапазон зависит от выбранного уровня сложности в настройках. По умолчанию это числа от 1 до 4(включительно).\n Кто раньше всех игроков привел загаданное число к 0, тот и победитель.\n Ну что, а теперь начнем!");
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
                            userTry = Console.ReadLine();
                            if (Convert.ToInt32(userTry) == 1 || Convert.ToInt32(userTry) == 2 || Convert.ToInt32(userTry) == 3)
                            {
                                DataValidation.Level = Convert.ToInt32(userTry);
                                Console.WriteLine("Сложность обновлена");
                            }
                            else
                                Сommand = userTry;
                            break;
                        }
                    case "Старт":
                        {
                            Console.WriteLine("Действует следующее правило:" + DataValidation.Level);
                            Console.WriteLine("Введите количество игроков. Для игры с компьютером введите '1'");
                            Players = Convert.ToUInt32(Console.ReadLine());
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

                            Number = ProgramClassHelper.gameNumber;
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

                                Console.WriteLine("Введите число");
                                if (UsersList[PlayerMove].Flag == 0)
                                    userTry = Console.ReadLine();
                                else
                                {
                                    userTry = Convert.ToString(ComputerStep.Step());
                                    Console.WriteLine(userTry);
                                }

                                if (!DataValidation.Validation(userTry))
                                {
                                    do
                                    {
                                        Console.WriteLine("Вы указали некорректное число");
                                        Console.WriteLine("Введите число");
                                        userTry = Console.ReadLine();
                                    }
                                    while (!DataValidation.Validation(userTry));
                                }
                                Number = Number - Convert.ToInt32(userTry);
                                Console.WriteLine("Игровое число равно: " + Number);
                            }
                            Console.WriteLine("Игра окончена. Игрок " + UsersList[PlayerMove].UserName + " Одержал победу. Поздравим его!");
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
