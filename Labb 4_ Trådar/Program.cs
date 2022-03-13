using System;
using System.Threading;

namespace Labb_3__Trådar
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread I = new Thread(Info);
            Thread R = new Thread(Ready);
            Thread S = new Thread(Set);
            Thread G = new Thread(Go);
            Racer R1 = new Racer("Thunderbolt", 0, 10000, 120, ".....", 0);
            Racer R2 = new Racer("\t\t\t\t\t\tFlashlight", 0, 10000, 120, "\t\t\t\t\t\t.....", 0);

            Thread Honda = new Thread(() => Race(R1));
            Thread Volvo = new Thread(() => Race(R2));

            I.Start();
            R.Start();
            S.Start();
            G.Start();
            Volvo.Start();
            Honda.Start();

        }
        public static void Info()
        {
            Console.WriteLine("\t\t\t\tInformation");
            Console.WriteLine("\t\tPress enter twice during race to see racer status!");
            Console.WriteLine();
        }
        public static void Ready()
        {
            Thread.Sleep(3000);
            Console.WriteLine("\t\t\t\tREADY");
        }
        public static void Set()
        {
            Thread.Sleep(4000);
            Console.WriteLine("\t\t\t\tSET");
        }
        public static void Go()
        {
            Thread.Sleep(5000);
            Console.WriteLine("\t\t\t\tGO");
        }
        public static void Race(Racer r)
        {
            Thread.Sleep(6000);
            Console.WriteLine($"{r.CarName} has started");
            for (int i = 0; i < r.Goal; i++)
            {
                r.Distance = r.Distance + (r.Speed /*/ 10) / 6*/);
                Console.WriteLine($"{r.DotDot}");
                Thread.Sleep(500);
                r.timer++;
                if (r.timer == 5)
                {
                    Random random = new Random();
                    int NumGen = random.Next(0, 50);
                    if (NumGen == 1)
                    {
                        Console.WriteLine($"{r.CarName} filling up gas");
                        Thread.Sleep(3000);
                        NumGen = 0;
                    }
                    if (NumGen == 2 && NumGen == 3)
                    {
                        Console.WriteLine($"{r.CarName} changing flat tire");
                        Thread.Sleep(2000);
                        NumGen = 0;
                    }
                    if (NumGen >= 4 && NumGen <= 8)
                    {
                        Console.WriteLine($"{r.CarName} wiping windshield off");
                        Thread.Sleep(1000);
                        NumGen = 0;
                    }
                    if (NumGen >= 9 && NumGen <= 18)
                    {
                        Console.WriteLine($"{r.CarName} has engine failure, slowing down");
                        Thread.Sleep(500);
                        r.Speed = r.Speed - 1;
                        NumGen = 0;
                    }
                    r.timer = 0;
                }
                if (r.Distance >= r.Goal)
                {
                    Console.WriteLine($"{r.CarName} was first to reach the goal!");
                    Console.WriteLine($"{r.CarName.ToUpper()} HAS WON");
                    Environment.Exit(0);
                }
                if (r.Speed == 0)
                {
                    Console.WriteLine($"{r.CarName} engine's broke down ");
                    break;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    Console.WriteLine($"{r.CarName} -- Distance: {r.Distance} /10.000 and Speed: {r.Speed}");
                }
            }
        }
    }
}
