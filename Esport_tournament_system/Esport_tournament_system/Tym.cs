using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esport_tournament_system
{
    public class Tym
    {
        private readonly List<Hrac> _hraci = new List<Hrac>();

        public string Nazev { get; private set; }

        public IReadOnlyList<Hrac> Hraci => _hraci.AsReadOnly();

        public int PocetVyher { get; private set; }
        public int PocetProher { get; private set; }
        public int PocetRemiz { get; private set; }
        public int PocetBodu { get; private set; }

        public int VstreleneGoly { get; private set; }
        public int ObdrzeneGoly { get; private set; }

        public int RozdilSkore => VstreleneGoly - ObdrzeneGoly;

        public Tym(string nazev)
        {
            if (string.IsNullOrWhiteSpace(nazev))
                throw new ArgumentException("Název týmu nesmí být prázdný.");

            Nazev = nazev;
        }

        // Přidání hráče do týmu
        public bool PridatHrace(Hrac hrac)
        {
            if (hrac == null)
                throw new ArgumentNullException(nameof(hrac));

            if (_hraci.Contains(hrac))
                return false;

            if (hrac.PrirazenyTym != null)
                throw new InvalidOperationException(
                    "Hráč už je přiřazen k jinému týmu.");

            _hraci.Add(hrac);
            hrac.PrirazenyTym = this;

            return true;
        }

        // Odebrání hráče z týmu
        public bool OdebratHrace(Hrac hrac)
        {
            if (hrac == null)
                throw new ArgumentNullException(nameof(hrac));

            if (!_hraci.Remove(hrac))
                return false;

            hrac.PrirazenyTym = null;

            return true;
        }

        // Evidence výsledku zápasu
        public void ZaznamenejVysledek(
            int vstreleneSkore,
            int obdrzeneSkore)
        {
            if (vstreleneSkore < 0 || obdrzeneSkore < 0)
                throw new ArgumentException("Skóre nesmí být záporné.");

            VstreleneGoly += vstreleneSkore;
            ObdrzeneGoly += obdrzeneSkore;

            if (vstreleneSkore > obdrzeneSkore)
            {
                PocetVyher++;
                PocetBodu += 3;
            }
            else if (vstreleneSkore < obdrzeneSkore)
            {
                PocetProher++;
            }
            else
            {
                PocetRemiz++;
                PocetBodu += 1;
            }
        }

        // Výpis hráčů týmu
        public void VypsatHrace()
        {
            Console.WriteLine($"Tým: {Nazev}");

            if (_hraci.Count == 0)
            {
                Console.WriteLine("Tým zatím nemá žádné hráče.");
                return;
            }

            foreach (Hrac hrac in _hraci)
            {
                Console.WriteLine($"- {hrac}");
            }
        }

        public override string ToString()
        {
            return $"{Nazev} | Hráči: {_hraci.Count} | " +
                   $"Výhry: {PocetVyher} | Prohry: {PocetProher} | " +
                   $"Body: {PocetBodu}";
        }
    }

}
