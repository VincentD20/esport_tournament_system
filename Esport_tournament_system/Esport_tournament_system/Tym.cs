
using System;
using System.Collections.Generic;
namespace Esport_tournament_system
{
    public class Tym
    {
        private readonly List<Hrac> _hraci = new List<Hrac>();

        public string Nazev { get; private set; }

        public IReadOnlyList<Hrac> Hraci => _hraci.AsReadOnly();

        public Tym(string nazev)
        {
            if (string.IsNullOrWhiteSpace(nazev))
                throw new ArgumentException(
                    "Název týmu nesmí být prázdný.");

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
                return false;

            _hraci.Add(hrac);
            hrac.PrirazenyTym = this;

            return true;
        }

        // Odebrání hráče z týmu
        public bool OdebratHrace(Hrac hrac)
        {
            if (hrac == null)
                throw new ArgumentNullException(nameof(hrac));

            if (hrac.PrirazenyTym != this)
                return false;

            if (!_hraci.Remove(hrac))
                return false;

            hrac.PrirazenyTym = null;

            return true;
        }

        // Výpis hráčů týmu
        public void VypsatHrace()
        {
            Console.WriteLine($"Tým: {Nazev}");

            if (_hraci.Count == 0)
            {
                Console.WriteLine(
                    "Tým zatím nemá žádné hráče.");
                return;
            }

            foreach (Hrac hrac in _hraci)
            {
                Console.WriteLine($"- {hrac}");
            }
        }

        public override string ToString()
        {
            return $"{Nazev} | Hráči: {_hraci.Count}";
        }
    }
}
