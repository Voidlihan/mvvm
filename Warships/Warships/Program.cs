using System;

namespace Warships
{
    class Program
    {
        //const int N = 10;

        public static void mapa(int[,] map)
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i,j]);
                }
            }
            Console.WriteLine();
        }

        public static void initships(int[,] map)
        {
            int x = 0, y = 0;
            Console.WriteLine("Расставьте кораблик по x, y: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                map[x,y] = 1;
            }
        }

        public static void initshipsBOT(int[,] map)
        {
            Random rand = new Random();
            int x, y;
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(0, 10);
                y = rand.Next(0, 10);
                map[x,y] = 1;
            }
        }

        public static bool proverka(int[,] map, int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[x,y - 1] == ' ' && map[x - 1,y] == ' '
                      && map[x + 1,y] == ' ' && map[x,y + 1] == ' ' &&
                      map[x - 1,y - 1] == ' ' && map[x - 1,y + 1] == ' '
                      && map[x + 1,y - 1] == ' '
                      && map[x + 1,y + 1] == ' ')
                    {
                        return true;
                        /*cout << "Выберите направление: " << endl;
                        cout << "1.По вертикали" << endl;
                        cout << "2.По горизонтали" << endl;
                        cout << "Ваш выбор: ";
                        int Vybor;
                        cin >> Vybor;
                        switch (Vybor){
                        case 1: break;
                        case 2: break;*/
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void hitshipsBOT(int[,] map)
        {
            Random rand = new Random();
            int x, y;
            Console.WriteLine();
            x = rand.Next(0, 10);
            y = rand.Next(0, 10);
            if (map[x,y] == 1)
            {
                map[x,y] = 0;
                bool sett = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i,j] == 1)
                        {
                            sett = true;
                            break;
                        }
                    }
                }
                if (sett == false)
                {
                    Console.WriteLine("Оппонент попал");
                }
                else
                {
                    Console.WriteLine("Бот тупой!");
                }
            }
            else
            {
            }
        }

        public static void hitships(int[,] map)
        {
            int x, y;
            Console.WriteLine("Введите координаты для выстрела: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            if (map[x,y] == 1)
            {
                Console.WriteLine("Ты попал!");
                map[x,y] = 0;
                bool sett = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i,j] == 1)
                        {
                            sett = true;
                            break;
                        }
                    }
                }
                if (sett == false)
                {
                    Console.WriteLine("Победа!");
                }
            }
            else
            {
                Console.WriteLine("Беда с башкой");
            }
        }
        static void Main(string[] args)
        {
            int[,] map = new int[10,10];
            int x, y;
            Console.WriteLine("Начните с x, а потом y и считайте с 0");
            initships(map);
            Console.WriteLine("Введите коорды куда хотите поставить корабль: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            proverka(map, x, y);
            mapa(map);
            Console.WriteLine();
            initshipsBOT(map);
            mapa(map);
            while (true)
            {

                hitships(map);
            }
        }
    }
}