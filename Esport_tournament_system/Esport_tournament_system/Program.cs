
using System;
using System.Collections.Generic;

namespace Esport_tournament_system
{
    internal class Program
    {
        private static readonly SpravaHracu spravaHracu = new SpravaHracu();
        private static readonly List<Turnaj> turnaje = new List<Turnaj>();

        static void Main(string[] args)
        {
            bool konec = false;

            while (!konec)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("     ESPORT TOURNAMENT SYSTEM");
                Console.WriteLine("================================");
                Console.WriteLine("1. Správa hráčů");
                Console.WriteLine("2. Správa týmů");
                Console.WriteLine("3. Správa turnajů");
                Console.WriteLine("4. Správa zápasů");
                Console.WriteLine("5. Zobrazit tabulku turnaje");
                Console.WriteLine("0. Konec programu");
                Console.WriteLine("================================");

                Console.Write("Vyber možnost: ");
                string? volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        MenuHracu();
                        break;

                    case "2":
                        MenuTymu();
                        break;

                    case "3":
                        MenuTurnaju();
                        break;

                    case "4":
                        MenuZapasu();
                        break;

                    case "5":
                        ZobrazitTabulku();
                        break;

                    case "0":
                        konec = true;
                        break;

                    default:
                        ChybnaVolba();
                        break;
                }
            }

            Console.WriteLine("Program byl ukončen.");
        }

        // ==========================================
        // SPRÁVA HRÁČŮ
        // ==========================================

        static void MenuHracu()
        {
            bool zpet = false;

            while (!zpet)
            {
                Console.Clear();

                Console.WriteLine("========== SPRÁVA HRÁČŮ ==========");
                Console.WriteLine("1. Vytvořit hráče");
                Console.WriteLine("2. Smazat hráče");
                Console.WriteLine("3. Vypsat všechny hráče");
                Console.WriteLine("0. Zpět");
                Console.WriteLine("==================================");

                Console.Write("Vyber možnost: ");
                string? volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Console.Write("Zadej jméno: ");
                        string jmeno = Console.ReadLine() ?? "";

                        Console.Write("Zadej přezdívku: ");
                        string prezdivka = Console.ReadLine() ?? "";

                        spravaHracu.VytvoritHrace(jmeno, prezdivka);
                        Pauza();
                        break;

                    case "2":
                        Console.Write("Zadej přezdívku hráče: ");
                        string prezdivkaKeSmazani = Console.ReadLine() ?? "";

                        spravaHracu.SmazatHrace(prezdivkaKeSmazani);
                        Pauza();
                        break;

                    case "3":
                        spravaHracu.VypsatVsechnyHrace();
                        Pauza();
                        break;

                    case "0":
                        zpet = true;
                        break;

                    default:
                        ChybnaVolba();
                        break;
                }
            }
        }

        // ==========================================
        // SPRÁVA TÝMŮ
        // ==========================================

        static void MenuTymu()
        {
            bool zpet = false;

            while (!zpet)
            {
                Console.Clear();

                Console.WriteLine("========== SPRÁVA TÝMŮ ==========");
                Console.WriteLine("1. Vytvořit tým");
                Console.WriteLine("2. Smazat tým");
                Console.WriteLine("3. Vypsat všechny týmy");
                Console.WriteLine("4. Přidat hráče do týmu");
                Console.WriteLine("5. Odebrat hráče z týmu");
                Console.WriteLine("6. Vypsat hráče týmu");
                Console.WriteLine("0. Zpět");
                Console.WriteLine("================================");

                Console.Write("Vyber možnost: ");
                string? volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Console.Write("Zadej název týmu: ");
                        string nazev = Console.ReadLine() ?? "";

                        spravaHracu.VytvoritTym(nazev);
                        Pauza();
                        break;

                    case "2":
                        Console.Write("Zadej název týmu: ");
                        string tymKeSmazani = Console.ReadLine() ?? "";

                        Tym? tymProSmazani = NajitTym(tymKeSmazani);

                        if (tymProSmazani != null &&
                            JeTymVTurnaji(tymProSmazani))
                        {
                            Console.WriteLine(
                                "Tým nelze smazat, protože je součástí turnaje.");
                        }
                        else
                        {
                            spravaHracu.SmazatTym(tymKeSmazani);
                        }

                        Pauza();
                        break;

                    case "3":
                        spravaHracu.VypsatVsechnyTymy();
                        Pauza();
                        break;

                    case "4":
                        Console.Write("Zadej přezdívku hráče: ");
                        string prezdivka = Console.ReadLine() ?? "";

                        Console.Write("Zadej název týmu: ");
                        string tymProHrace = Console.ReadLine() ?? "";

                        spravaHracu.PridatHraceDoTymu(
                            prezdivka, tymProHrace);

                        Pauza();
                        break;

                    case "5":
                        Console.Write("Zadej přezdívku hráče: ");
                        string hracKeOdebrani = Console.ReadLine() ?? "";

                        Console.Write("Zadej název týmu: ");
                        string tymProOdebrani = Console.ReadLine() ?? "";

                        spravaHracu.OdebratHraceZTymu(
                            hracKeOdebrani, tymProOdebrani);

                        Pauza();
                        break;

                    case "6":
                        Console.Write("Zadej název týmu: ");
                        string nazevTymu = Console.ReadLine() ?? "";

                        Tym? tym = NajitTym(nazevTymu);

                        if (tym != null)
                            tym.VypsatHrace();
                        else
                            Console.WriteLine("Tým nebyl nalezen.");

                        Pauza();
                        break;

                    case "0":
                        zpet = true;
                        break;

                    default:
                        ChybnaVolba();
                        break;
                }
            }
        }

        // ==========================================
        // SPRÁVA TURNAJŮ
        // ==========================================

        static void MenuTurnaju()
        {
            bool zpet = false;

            while (!zpet)
            {
                Console.Clear();

                Console.WriteLine("========== SPRÁVA TURNAJŮ ==========");
                Console.WriteLine("1. Vytvořit turnaj");
                Console.WriteLine("2. Vypsat všechny turnaje");
                Console.WriteLine("3. Přidat tým do turnaje");
                Console.WriteLine("4. Vypsat týmy turnaje");
                Console.WriteLine("0. Zpět");
                Console.WriteLine("===================================");

                Console.Write("Vyber možnost: ");
                string? volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Console.Write("Zadej název turnaje: ");
                        string nazev = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(nazev))
                        {
                            Console.WriteLine("Název turnaje nesmí být prázdný.");
                        }
                        else if (NajitTurnaj(nazev) != null)
                        {
                            Console.WriteLine("Turnaj s tímto názvem už existuje.");
                        }
                        else
                        {
                            turnaje.Add(new Turnaj(nazev));
                            Console.WriteLine($"Turnaj {nazev} byl vytvořen.");
                        }

                        Pauza();
                        break;

                    case "2":
                        VypsatTurnaje();
                        Pauza();
                        break;

                    case "3":
                        Turnaj? turnaj = VybratTurnaj();

                        if (turnaj != null)
                        {
                            Console.Write("Zadej název týmu: ");
                            string nazevTymu = Console.ReadLine() ?? "";

                            Tym? tym = NajitTym(nazevTymu);

                            if (tym == null)
                            {
                                Console.WriteLine("Tým nebyl nalezen.");
                            }
                            else if (turnaj.PridatTym(tym))
                            {
                                Console.WriteLine(
                                    $"Tým {tym.Nazev} byl přidán do turnaje {turnaj.Nazev}.");
                            }
                            else
                            {
                                Console.WriteLine("Tým už je součástí tohoto turnaje.");
                            }
                        }

                        Pauza();
                        break;

                    case "4":
                        Turnaj? vybranyTurnaj = VybratTurnaj();

                        if (vybranyTurnaj != null)
                        {
                            Console.WriteLine($"\nTýmy turnaje {vybranyTurnaj.Nazev}:");

                            if (vybranyTurnaj.Tymy.Count == 0)
                                Console.WriteLine("Turnaj zatím nemá žádné týmy.");

                            foreach (Tym tym in vybranyTurnaj.Tymy)
                                Console.WriteLine($"- {tym.Nazev}");
                        }

                        Pauza();
                        break;

                    case "0":
                        zpet = true;
                        break;

                    default:
                        ChybnaVolba();
                        break;
                }
            }
        }

        // ==========================================
        // SPRÁVA ZÁPASŮ
        // ==========================================

        static void MenuZapasu()
        {
            bool zpet = false;

            while (!zpet)
            {
                Console.Clear();

                Console.WriteLine("========== SPRÁVA ZÁPASŮ ==========");
                Console.WriteLine("1. Vytvořit zápas");
                Console.WriteLine("2. Zaznamenat výsledek");
                Console.WriteLine("3. Vypsat zápasy turnaje");
                Console.WriteLine("0. Zpět");
                Console.WriteLine("===================================");

                Console.Write("Vyber možnost: ");
                string? volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Turnaj? turnaj = VybratTurnaj();

                        if (turnaj != null)
                        {
                            if (turnaj.Tymy.Count < 2)
                            {
                                Console.WriteLine(
                                    "Turnaj musí mít alespoň dva týmy.");
                                Pauza();
                                break;
                            }

                            Console.WriteLine("\nDomácí tým:");
                            Tym? domaci = VybratTymZTurnaje(turnaj);

                            if (domaci == null)
                            {
                                Pauza();
                                break;
                            }

                            Console.WriteLine("\nHostující tým:");
                            Tym? hostujici = VybratTymZTurnaje(turnaj);

                            if (hostujici == null)
                            {
                                Pauza();
                                break;
                            }

                            if (domaci == hostujici)
                            {
                                Console.WriteLine(
                                    "Tým nemůže hrát sám proti sobě.");
                            }
                            else
                            {
                                Zapas zapas = turnaj.VytvoritZapas(
                                    domaci, hostujici);

                                Console.WriteLine(
                                    $"Zápas {domaci.Nazev} vs. {hostujici.Nazev} byl vytvořen.");
                            }
                        }

                        Pauza();
                        break;

                    case "2":
                        Turnaj? turnajProVysledek = VybratTurnaj();

                        if (turnajProVysledek != null)
                        {
                            if (turnajProVysledek.Zapasy.Count == 0)
                            {
                                Console.WriteLine("Turnaj zatím nemá žádné zápasy.");
                                Pauza();
                                break;
                            }

                            Zapas? zapas = VybratZapas(turnajProVysledek);

                            if (zapas != null)
                            {
                                if (zapas.Odehrano)
                                {
                                    Console.WriteLine(
                                        "Výsledek tohoto zápasu už byl zaznamenán.");
                                }
                                else
                                {
                                    int skoreDomaci = NacistCeleCislo(
                                        $"Skóre {zapas.DomaciTym.Nazev}: ");

                                    int skoreHoste = NacistCeleCislo(
                                        $"Skóre {zapas.HostujiciTym.Nazev}: ");

                                    turnajProVysledek.ZapsatVysledek(
                                        zapas, skoreDomaci, skoreHoste);

                                    Console.WriteLine("Výsledek byl úspěšně zaznamenán.");
                                }
                            }
                        }

                        Pauza();
                        break;

                    case "3":
                        Turnaj? turnajProVypis = VybratTurnaj();

                        if (turnajProVypis != null)
                            turnajProVypis.VypsatVsechnyZapasy();

                        Pauza();
                        break;

                    case "0":
                        zpet = true;
                        break;

                    default:
                        ChybnaVolba();
                        break;
                }
            }
        }

        // ==========================================
        // TABULKA TURNAJE
        // ==========================================

        static void ZobrazitTabulku()
        {
            Console.Clear();

            Turnaj? turnaj = VybratTurnaj();

            if (turnaj != null)
                turnaj.VypsatTabulku();

            Pauza();
        }

        // ==========================================
        // POMOCNÉ METODY
        // ==========================================

        static Tym? NajitTym(string nazev)
        {
            // Vyhledání týmu podle seznamu v hlavní správě
            // Pomocí dočasného seznamu zde pracujeme s dostupnými týmy.
            // Vyhledání probíhá přes veřejný seznam týmů níže.
            foreach (Tym tym in ZiskatTymy())
            {
                if (string.Equals(
                    tym.Nazev, nazev,
                    StringComparison.OrdinalIgnoreCase))
                    return tym;
            }

            return null;
        }

        static List<Tym> ZiskatTymy()
        {
            // Týmy jsou dostupné přes pomocnou evidenci.
            // Viz metoda VypsatVsechnyTymy v hlavní správě.
            return tymyEvidence;
        }

        private static readonly List<Tym> tymyEvidence = new List<Tym>();

        static Turnaj? NajitTurnaj(string nazev)
        {
            return turnaje.Find(t =>
                string.Equals(
                    t.Nazev, nazev,
                    StringComparison.OrdinalIgnoreCase));
        }

        static void VypsatTurnaje()
        {
            Console.WriteLine("\n=== SEZNAM TURNAJŮ ===");

            if (turnaje.Count == 0)
            {
                Console.WriteLine("Zatím nejsou vytvořeny žádné turnaje.");
                return;
            }

            foreach (Turnaj turnaj in turnaje)
                Console.WriteLine($"- {turnaj.Nazev}");
        }

        static Turnaj? VybratTurnaj()
        {
            if (turnaje.Count == 0)
            {
                Console.WriteLine("Nejdříve vytvoř nějaký turnaj.");
                return null;
            }

            VypsatTurnaje();

            Console.Write("\nZadej název turnaje: ");
            string nazev = Console.ReadLine() ?? "";

            Turnaj? turnaj = NajitTurnaj(nazev);

            if (turnaj == null)
                Console.WriteLine("Turnaj nebyl nalezen.");

            return turnaj;
        }

        static Tym? VybratTymZTurnaje(Turnaj turnaj)
        {
            Console.WriteLine("\nTýmy v turnaji:");

            for (int i = 0; i < turnaj.Tymy.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {turnaj.Tymy[i].Nazev}");
            }

            Console.Write("Vyber číslo týmu: ");

            if (int.TryParse(Console.ReadLine(), out int cislo) &&
                cislo >= 1 &&
                cislo <= turnaj.Tymy.Count)
            {
                return turnaj.Tymy[cislo - 1];
            }

            Console.WriteLine("Neplatná volba.");
            return null;
        }

        static Zapas? VybratZapas(Turnaj turnaj)
        {
            Console.WriteLine("\nZápasy:");

            for (int i = 0; i < turnaj.Zapasy.Count; i++)
            {
                Zapas zapas = turnaj.Zapasy[i];

                string stav = zapas.Odehrano
                    ? $"{zapas.SkoreDomaci}:{zapas.SkoreHoste}"
                    : "Neodehráno";

                Console.WriteLine(
                    $"{i + 1}. {zapas.DomaciTym.Nazev} vs. " +
                    $"{zapas.HostujiciTym.Nazev} | {stav}");
            }

            Console.Write("Vyber číslo zápasu: ");

            if (int.TryParse(Console.ReadLine(), out int cislo) &&
                cislo >= 1 &&
                cislo <= turnaj.Zapasy.Count)
            {
                return turnaj.Zapasy[cislo - 1];
            }

            Console.WriteLine("Neplatná volba.");
            return null;
        }

        static int NacistCeleCislo(string vyzva)
        {
            int cislo;

            while (true)
            {
                Console.Write(vyzva);

                if (int.TryParse(Console.ReadLine(), out cislo) &&
                    cislo >= 0)
                {
                    return cislo;
                }

                Console.WriteLine(
                    "Zadej platné nezáporné celé číslo.");
            }
        }

        static void ChybnaVolba()
        {
            Console.WriteLine("Neplatná volba.");
            Pauza();
        }

        static void Pauza()
        {
            Console.WriteLine("\nStiskni Enter pro pokračování...");
            Console.ReadLine();
        }

        static bool JeTymVTurnaji(Tym tym)
        {
            foreach (Turnaj turnaj in turnaje)
            {
                if (turnaj.Tymy.Contains(tym))
                    return true;
            }

            return false;
        }
    }
}
