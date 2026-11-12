using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esport_tournament_system
{

    public class Hrac
    {
        public string Jmeno { get; private set; }
        public string Prezdivka { get; private set; }

        // Tým, ve kterém hráč aktuálně působí
        public Tym? PrirazenyTym { get; internal set; }

        public Hrac(string jmeno, string prezdivka)
        {
            if (string.IsNullOrWhiteSpace(jmeno))
                throw new ArgumentException("Jméno nesmí být prázdné.");

            if (string.IsNullOrWhiteSpace(prezdivka))
                throw new ArgumentException("Přezdívka nesmí být prázdná.");

            Jmeno = jmeno;
            Prezdivka = prezdivka;
        }

        public override string ToString()
        {
            return $"{Prezdivka} ({Jmeno})";
        }
    }

}
