using System;
using System.Collections.Generic;

namespace ZaDuzoZaMalo
{
    public class Game
    {
        public enum Odp {ZaMalo = -1, Trafiono, ZaDuzo };
        public enum Stan { Trwa, Poddana, Odgadnieta };

        public Stan StanGry { get; private set; }

        private readonly int wylosowana;
        public readonly int zakresOd;
        public readonly int zakresDo;
        public int LicznikRuchow { get; private set; }

        //historia gry: propozycja, ocena, kiedy
        private List<Ruch> historia;
        public IReadOnlyList<Ruch> Historia => historia.AsReadOnly();
        
        public Game(int a = 1, int b = 100)
        {
            if (a > b)
            {
                zakresOd = b;
                zakresDo = a;
            }
            else
            {
                zakresOd = a;
                zakresDo = b;
            }

            var generator = new Random();
            wylosowana = generator.Next(zakresOd, zakresDo + 1);
            StanGry = Stan.Trwa;
            historia = new List<Ruch>();
        }
        public Odp Ocena( int propozycja )
        {
            Game.Odp odp;

            if (wylosowana == propozycja)
            {
                odp = Odp.Trafiono;
                StanGry = Stan.Odgadnieta;
            }
            else if (wylosowana < propozycja)
                odp = Odp.ZaDuzo;
            else
                odp = Odp.ZaMalo;

            //zapisz historię
            historia.Add(new Ruch(propozycja, odp));
            LicznikRuchow++;

            return odp;
        }

        public void Poddaj()
        {
            StanGry = Stan.Poddana;
        }
        public int? Wylosowana
        {
            get
            {
                if (!(StanGry == Stan.Trwa))
                    return wylosowana;
                else
                    return null;
            }            
        }

        public override string ToString()
        {
            return $"Wylosowana z zakresu: {zakresOd}..{zakresDo}";
        }
        public class Ruch
        {
            public readonly int propozycja;
            public readonly Game.Odp odp;
            public readonly DateTime kiedy;
            public static int Licznik { get; private set; } = 0;

            public Ruch(int propozycja, Game.Odp odp)
            {
                this.propozycja = propozycja;
                this.odp = odp;
                kiedy = DateTime.Now;
                Licznik++;
            }
        }
    }
}