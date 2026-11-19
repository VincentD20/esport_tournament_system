
using System;

namespace Esport_tournament_system
{
    public class Zapas
    {
        // Týmy
        public Tym DomaciTym { get; private set; }
        public Tym HostujiciTym { get; private set; }

        // Skóre
        public int SkoreDomaci { get; private set; }
        public int SkoreHoste { get; private set; }

        // Vítěz zápasu (null při remíze)
        public Tym? Vitez { get; private set; }

        // Stav zápasu
        public bool Odehrano { get; private set; }

        // Konstruktor – zápas vytváří Turnaj
        internal Zapas(Tym domaci, Tym hostujici)
        {
            if (domaci == null)
                throw new ArgumentNullException(nameof(domaci));

            if (hostujici == null)
                throw new ArgumentNullException(nameof(hostujici));

            if (domaci == hostujici)
                throw new ArgumentException(
                    "Tým nemůže hrát sám proti sobě.");

            DomaciTym = domaci;
            HostujiciTym = hostujici;

            Odehrano = false;
            Vitez = null;
        }

        // Zapsání výsledku – volá Turnaj
        internal void ZapsatVysledek(
            int skoreDomaci,
            int skoreHoste)
        {
            if (Odehrano)
                throw new InvalidOperationException(
                    "Výsledek tohoto zápasu už byl zaznamenán.");

            if (skoreDomaci < 0 || skoreHoste < 0)
                throw new ArgumentException(
                    "Skóre nesmí být záporné.");

            SkoreDomaci = skoreDomaci;
            SkoreHoste = skoreHoste;

            // Určení vítěze
            if (SkoreDomaci > SkoreHoste)
            {
                Vitez = DomaciTym;
            }
            else if (SkoreDomaci < SkoreHoste)
            {
                Vitez = HostujiciTym;
            }
            else
            {
                Vitez = null;
            }

            Odehrano = true;
        }

        // Výpis jednoho zápasu
        public void VypsatZapas()
        {
            Console.WriteLine("--------------------------------");

            Console.WriteLine(
                $"{DomaciTym.Nazev} vs. {HostujiciTym.Nazev}");

            if (Odehrano)
            {
                Console.WriteLine(
                    $"Výsledek: {SkoreDomaci} : {SkoreHoste}");

                if (Vitez != null)
                    Console.WriteLine($"Vítěz: {Vitez.Nazev}");
                else
                    Console.WriteLine("Výsledek: Remíza");
            }
            else
            {
                Console.WriteLine(
                    "Zápas zatím nebyl odehrán.");
            }

            Console.WriteLine("--------------------------------");
        }
    }
}
