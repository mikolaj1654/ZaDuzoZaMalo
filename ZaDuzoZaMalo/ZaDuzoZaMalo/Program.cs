using System;

namespace ZaDuzoZaMalo
{
    class Program
    {
        private static bool PlayAgain = true;
        public static int NumberOfSessions = 0;
        public static int BestScore = 1;
        static void Main(string[] args)
        {
            do
            {
                Game g = new Game(1, 10);
                
                Console.WriteLine("Podaj liczbe:");
                Game.Odp odp = g.Ocena(int.Parse(Console.ReadLine()));
                Console.WriteLine(odp);
                while (odp != Game.Odp.Trafiono)
                {
                    odp = g.Ocena((int.Parse(Console.ReadLine())));
                    Console.WriteLine(odp);
                }
                
                Console.WriteLine("--------------------\n");
                Console.WriteLine("Twoja ilość punktów wynosi: ");
                Console.WriteLine(g.LicznikRuchow);
                Console.WriteLine("--------------------\n");

                foreach (var ruch in g.Historia)
                {
                    Console.WriteLine($"{ruch.propozycja} {ruch.odp} {ruch.kiedy}");
                }
                
                Console.WriteLine("\nCzy chcesz zagrać ponownie? tak/nie");
                var response = Console.ReadLine();

                if (response == "tak")
                    PlayAgain = true;
                else
                {
                    Console.WriteLine(String.Format("\nNajlepszy wynik wynosi: {0}",BestScore));
                    Console.WriteLine(String.Format("Ilość sesji wynosi: {0}",NumberOfSessions));
                    PlayAgain = false;
                }
                
                
            } while (PlayAgain is true);

        }
    }
}