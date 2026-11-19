using System;
using System.Collections.Generic;
using System.Linq;

namespace Esport_tournament_system
{
    public class Turnaj
    {
        private readonly List<Tym> _tymy = new List<Tym>();

        public string Nazev { get; }

        public IReadOnlyList<Tym> Tymy => _tymy.AsReadOnly();

        public IReadOnlyDictionary<Tym, StatistikyTymu> Statistiky =>
            _tymy.ToDictionary(tym => tym, tym => new StatistikyTymu(tym));

        public Turnaj(string nazev)
        {
            if (string.IsNullOrWhiteSpace(nazev))
                throw new ArgumentException("Název turnaje nesmí být prázdný.");

            Nazev = nazev;
        }

        public bool PridatTym(Tym tym)
        {
            if (tym == null)
                throw new ArgumentNullException(nameof(tym));

            if (_tymy.Contains(tym))
                return false;

            _tymy.Add(tym);
            return true;
        }

        public IReadOnlyList<Tym> VytvoritTabulku()
        {
            return _tymy
                .OrderBy(tym => tym.PocetBodu)
                .ThenBy(tym => tym.RozdilSkore)
                .ThenBy(tym => tym.Nazev)
                .ToList()
                .AsReadOnly();
        }
    }

    public sealed class StatistikyTymu
    {
        public int Vyhry { get; }
        public int Prohry { get; }
        public int Remizy { get; }
        public int Body { get; }

        internal StatistikyTymu(Tym tym)
        {
            Vyhry = tym.PocetVyher;
            Prohry = tym.PocetProher;
            Remizy = tym.PocetRemiz;
            Body = tym.PocetBodu;
        }
    }
}
