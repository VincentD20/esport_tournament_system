
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Esport_tournament_system
{
    public class Turnaj
    {
        private readonly List<Tym> _tymy = new List<Tym>();
        private readonly List<Zapas> _zapasy = new List<Zapas>();

        private readonly Dictionary<Tym, StatistikyTymu> _statistiky
            = new Dictionary<Tym, StatistikyTymu>();

        public string Nazev { get; }

        public IReadOnlyList<Tym> Tymy => _tymy.AsReadOnly();

        public IReadOnlyList<Zapas> Zapasy => _zapasy.AsReadOnly();

        public IReadOnlyDictionary<Tym, StatistikyTymu> Statistiky =>
            new ReadOnlyDictionary<Tym, StatistikyTymu>(_statistiky);

        public Turnaj(string nazev)
        {
            if (string.IsNullOrWhiteSpace(nazev))
                throw new ArgumentException(
                    "Název turnaje nesmí být prázdný.");

            Nazev = nazev;
        }

        // Přidání týmu do turnaje
        public bool PridatTym(Tym tym)
        {
            if (tym == null)
                throw new ArgumentNullException(nameof(tym));

            if (_tymy.Contains(tym))
                return false;

            _tymy.Add(tym);

            // Každý turnaj má vlastní statistiky týmu
            _statistiky.Add(tym, new StatistikyTymu());

            return true;
        }

        // Vytvoření zápasu mezi dvěma týmy turnaje
        public Zapas VytvoritZapas(Tym domaci, Tym hostujici)
        {
            if (domaci == null)
                throw new ArgumentNullException(nameof(domaci));

            if (hostujici == null)
                throw new ArgumentNullException(nameof(hostujici));

            if (!_tymy.Contains(domaci) || !_tymy.Contains(hostujici))
                throw new InvalidOperationException(
                    "Oba týmy musí být součástí tohoto turnaje.");

            if (domaci == hostujici)
                throw new ArgumentException(
                    "Tým nemůže hrát sám proti sobě.");

            Zapas novyZapas = new Zapas(domaci, hostujici);

            _zapasy.Add(novyZapas);

            return novyZapas;
        }

        // Zaznamenání výsledku zápasu a aktualizace statistik
        public void ZapsatVysledek(
            Zapas zapas,
            int skoreDomaci,
            int skoreHoste)
        {
            if (zapas == null)
                throw new ArgumentNullException(nameof(zapas));

            if (!_zapasy.Contains(zapas))
                throw new InvalidOperationException(
                    "Zápas nepatří do tohoto turnaje.");

            // Zapsání výsledku zápasu
            zapas.ZapsatVysledek(skoreDomaci, skoreHoste);

            // Aktualizace statistik domácího týmu
            _statistiky[zapas.DomaciTym].ZaznamenejVysledek(
                skoreDomaci, skoreHoste);

            // Aktualizace statistik hostujícího týmu
            _statistiky[zapas.HostujiciTym].ZaznamenejVysledek(
                skoreHoste, skoreDomaci);
        }

        // Vytvoření tabulky pořadí
        public IReadOnlyList<Tym> VytvoritTabulku()
        {
            return _tymy
                .OrderByDescending(
                    tym => _statistiky[tym].Body)
                .ThenByDescending(
                    tym => _statistiky[tym].RozdilSkore)
                .ThenBy(
                    tym => tym.Nazev)
                .ToList()
                .AsReadOnly();
        }

        // Výpis všech zápasů turnaje
        public void VypsatVsechnyZapasy()
        {
            Console.WriteLine($"\n=== ZÁPASY: {Nazev} ===");

            if (_zapasy.Count == 0)
            {
                Console.WriteLine(
                    "V tomto turnaji zatím nejsou žádné zápasy.");
                return;
            }

            foreach (Zapas zapas in _zapasy)
            {
                zapas.VypsatZapas();
            }
        }

        // Výpis tabulky turnaje
        public void VypsatTabulku()
        {
            Console.WriteLine($"\n=== TABULKA: {Nazev} ===");

            if (_tymy.Count == 0)
            {
                Console.WriteLine(
                    "V turnaji zatím nejsou žádné týmy.");
                return;
            }

            int poradi = 1;

            foreach (Tym tym in VytvoritTabulku())
            {
                StatistikyTymu statistiky = _statistiky[tym];

                Console.WriteLine(
                    $"{poradi}. {tym.Nazev} | " +
                    $"Body: {statistiky.Body} | " +
                    $"V: {statistiky.Vyhry} | " +
                    $"R: {statistiky.Remizy} | " +
                    $"P: {statistiky.Prohry} | " +
                    $"Skóre: {statistiky.VstreleneGoly}:" +
                    $"{statistiky.ObdrzeneGoly} | " +
                    $"Rozdíl: {statistiky.RozdilSkore}");

                poradi++;
            }
        }
    }

    // Statistiky jednoho týmu v konkrétním turnaji
    public sealed class StatistikyTymu
    {
        public int Vyhry { get; private set; }
        public int Prohry { get; private set; }
        public int Remizy { get; private set; }
        public int Body { get; private set; }

        public int VstreleneGoly { get; private set; }
        public int ObdrzeneGoly { get; private set; }

        public int RozdilSkore =>
            VstreleneGoly - ObdrzeneGoly;

        public int PocetOdehranychZapasu =>
            Vyhry + Prohry + Remizy;

        internal StatistikyTymu()
        {
        }

        // Aktualizace statistik po odehraném zápase
        internal void ZaznamenejVysledek(
            int vstreleneSkore,
            int obdrzeneSkore)
        {
            VstreleneGoly += vstreleneSkore;
            ObdrzeneGoly += obdrzeneSkore;

            if (vstreleneSkore > obdrzeneSkore)
            {
                Vyhry++;
                Body += 3;
            }
            else if (vstreleneSkore < obdrzeneSkore)
            {
                Prohry++;
            }
            else
            {
                Remizy++;
                Body++;
            }
        }
    }
}
