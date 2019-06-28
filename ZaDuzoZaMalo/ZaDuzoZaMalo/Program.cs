using System;

namespace ZaDuzoZaMalo
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(1, 10);
            
            Console.WriteLine("Podaj liczbe:");
            Game.Odp odp = g.Ocena(int.Parse(Console.ReadLine()));
            Console.WriteLine( odp );
            while (odp != Game.Odp.Trafiono)
            {
                odp = g.Ocena((int.Parse(Console.ReadLine())));
                Console.WriteLine(odp);
            }
            /*if (odp != Game.Odp.Trafiono)
                odp = g.Ocena(7);
            if (odp != Game.Odp.Trafiono)
                odp = g.Ocena(3);*/

            foreach( var ruch in g.Historia )
            {
                Console.WriteLine( $"{ruch.propozycja} {ruch.odp} {ruch.kiedy}");
            }
        }
    }
}