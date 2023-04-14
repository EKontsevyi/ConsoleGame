using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleAppYoutube
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MessageBox.Show("Собери все сокровища 'Х'\n\nИ не взорвись на бомбах 'O'");
            //Console.CursorVisible = false;
            char[,] map = GetMap();

            Random ran = new Random();
            int complexity = 20;
            int maxLives = 7;
            int lives = maxLives;
            int presents = 0;

            for (int i = 0; i < complexity; i++)
            {
                int ranX = ran.Next(1, 22);
                int ranY = ran.Next(1, 22);

                map[ranX, ranY] = 'X';
                map[ranY, ranX] = 'O';
            }


            int userX = 6, userY = 5;

            char[] bag = new char[1];
            
            foreach (char item in map)
            {
                if (item == 'X')
                {
                    presents++;
                }

            }
            int maxPresents = presents;


            while (true)
            {

                Console.SetCursorPosition(0, 23);
                Console.Write($"Сумка: {maxPresents-presents}");

                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                
                DrawBar($"Жизни {lives}",lives, maxLives, ConsoleColor.Green, 24);
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"Осталось собрать: {presents}");
                

                PrintMap(map);


                Console.SetCursorPosition(userY, userX);
                PlayerBluePerson();
                ConsoleKeyInfo charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = ' ';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];

                    }
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;

                    presents--;
                }

                if (map[userX, userY] == 'O')
                {
                    map[userX, userY] = ' ';
                    lives--;
                    MessageBox.Show($"BOOOOOM!!!\n\n У тебя осталось {lives} жиздней"); ;
                }
                if (lives == 0)
                {
                    MessageBox.Show("ТЫ  УМЕР\n\nИГРА ОКОНЧЕНА");
                    break;
                }
                if (presents == 0)
                {
                    MessageBox.Show("Все сокровища собраны!\n\nТы выиграл!");
                    break;
                }

                Console.Clear();

            }
        }

        static void PlayerBluePerson()
        {
            ConsoleColor deaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('@');
            Console.ForegroundColor = deaultColor;

        }

        static void PrintMap(char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

        }
        static char[,] GetMap()
        {
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
            };
            return map;
        }
        static void DrawBar(string nameBar, int value, int maxValue, ConsoleColor color, int position)
        {
            Console.CursorVisible = false;
            
            ConsoleColor defaultCollor = Console.BackgroundColor;
            string bar = "";
            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }

            Console.SetCursorPosition(0, position);
            Console.Write(nameBar + ": [");
            if(value <= (maxValue*30)/100) {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
            Console.BackgroundColor = color;
            }
            Console.Write(bar);
            Console.BackgroundColor = defaultCollor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }
            Console.Write(bar + ']');

        }
    }
}



