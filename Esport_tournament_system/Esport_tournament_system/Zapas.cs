
using System;
using System.Collections.Generic;

namespace Esport_tournament_system
{
    public class Zapas
    {
        // Seznam všech zápasů
        public static List<Zapas> SeznamZapasu { get; }
            = new List<Zapas>();

        // Týmy
        public Tym DomaciTym { get; private set; }
        public Tym HostujiciTym { get; private set; }

        // Skóre
        public int SkoreDomaci { get; private set; }
        public int SkoreHoste { get; private set; }

        // Vítěz zápasu
        public Tym Vitez { get; private set; }

        // Stav zápasu
        public bool Odehrano { get; private set; }

        // Konstruktor
        public Zapas(Tym domaci, Tym hostujici)
        {
            if (domaci == null || hostujici == null)
                throw new ArgumentNullException("Týmy nesmí být null.");

            if (domaci == hostujici)
                throw new ArgumentException(
                    "Tým nemůže hrát sám proti sobě.");

            DomaciTym = domaci;
            HostujiciTym = hostujici;

            Odehrano = false;
            Vitez = null;

            SeznamZapasu.Add(this);
        }

        // Zapsání výsledku zápasu
        public void ZapsatVysledek(int skoreDomaci, int skoreHoste)
        {
            if (Odehrano)
                throw new InvalidOperationException(
                    "Výsledek tohoto zápasu už byl zaznamenán.");

            if (skoreDomaci < 0 || skoreHoste < 0)
                throw new ArgumentException(
                    "Skóre nesmí být záporné.");

            SkoreDomaci = skoreDomaci;
            SkoreHoste = skoreHoste;

            // Aktualizace statistik obou týmů
            DomaciTym.ZaznamenejVysledek(
                SkoreDomaci, SkoreHoste);

            HostujiciTym.ZaznamenejVysledek(
                SkoreHoste, SkoreDomaci);

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
                Console.WriteLine("Zápas zatím nebyl odehrán.");
            }

            Console.WriteLine("--------------------------------");
        }

        // Výpis všech zápasů
        public static void VypsatVsechnyZapasy()
        {
            if (SeznamZapasu.Count == 0)
            {
                Console.WriteLine(
                    "Zatím nebyly vytvořeny žádné zápasy.");
                return;
            }

            foreach (Zapas zapas in SeznamZapasu)
            {
                zapas.VypsatZapas();
            }
        }
    }
}
