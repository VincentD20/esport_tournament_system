using Esport_tournament_system;
using System;
using System.Collections.Generic;

public class SpravaHracu
{
    private readonly List<Hrac> _hraci = new List<Hrac>();
    private readonly List<Tym> _tymy = new List<Tym>();
    public Hrac? VytvoritHrace(string jmeno, string prezdivka)
    {
        // Kontrola duplicitní přezdívky
        foreach (Hrac hrac in _hraci)
        {
            if (string.Equals(
                hrac.Prezdivka,
                prezdivka,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Hráč s touto přezdívkou už existuje.");
                return null;
            }
        }

        // Vytvoření a uložení hráče
        Hrac novyHrac = new Hrac(jmeno, prezdivka);
        _hraci.Add(novyHrac);

        Console.WriteLine($"Hráč {prezdivka} byl vytvořen.");

        return novyHrac;
    }
    public Tym? VytvoritTym(string nazev)
    {
        // Kontrola duplicitního názvu
        foreach (Tym tym in _tymy)
        {
            if (string.Equals(
                tym.Nazev,
                nazev,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Tým s tímto názvem už existuje.");
                return null;
            }
        }

        // Vytvoření a uložení týmu
        Tym novyTym = new Tym(nazev);
        _tymy.Add(novyTym);

        Console.WriteLine($"Tým {nazev} byl vytvořen.");

        return novyTym;
    }
    public bool SmazatHrace(string prezdivka)
    {
        // Vyhledání hráče podle přezdívky
        Hrac? hrac = null;

        foreach (Hrac hledany in _hraci)
        {
            if (string.Equals(
                hledany.Prezdivka,
                prezdivka,
                StringComparison.OrdinalIgnoreCase))
            {
                hrac = hledany;
                break;
            }
        }

        // Kontrola, zda hráč existuje
        if (hrac == null)
        {
            Console.WriteLine("Hráč nebyl nalezen.");
            return false;
        }

        // Odebrání hráče z týmu, pokud v nějakém je
        if (hrac.PrirazenyTym != null)
        {
            hrac.PrirazenyTym.OdebratHrace(hrac);
        }

        // Odstranění hráče z evidence
        _hraci.Remove(hrac);

        Console.WriteLine($"Hráč {prezdivka} byl smazán.");

        return true;
    }
    public bool SmazatTym(string nazev)
    {
        // Vyhledání týmu
        Tym? tym = null;

        foreach (Tym hledany in _tymy)
        {
            if (string.Equals(
                hledany.Nazev,
                nazev,
                StringComparison.OrdinalIgnoreCase))
            {
                tym = hledany;
                break;
            }
        }

        // Kontrola, zda tým existuje
        if (tym == null)
        {
            Console.WriteLine("Tým nebyl nalezen.");
            return false;
        }

        // Odebrání všech hráčů z týmu
        foreach (Hrac hrac in tym.Hraci.ToList())
        {
            tym.OdebratHrace(hrac);
        }

        // Odstranění týmu z evidence
        _tymy.Remove(tym);

        Console.WriteLine($"Tým {nazev} byl smazán.");

        return true;
    }
    public void VypsatVsechnyHrace()
    {
        Console.WriteLine("\n=== SEZNAM HRÁČŮ ===");

        if (_hraci.Count == 0)
        {
            Console.WriteLine("Zatím nejsou registrováni žádní hráči.");
            return;
        }

        foreach (Hrac hrac in _hraci)
        {
            string tym = hrac.PrirazenyTym?.Nazev ?? "Bez týmu";

            Console.WriteLine(
                $"Jméno: {hrac.Jmeno} | " +
                $"Přezdívka: {hrac.Prezdivka} | " +
                $"Tým: {tym}");
        }
    }
    public void VypsatVsechnyTymy()
    {
        Console.WriteLine("\n=== SEZNAM TÝMŮ ===");

        if (_tymy.Count == 0)
        {
            Console.WriteLine("Zatím nejsou vytvořeny žádné týmy.");
            return;
        }

        foreach (Tym tym in _tymy)
        {
            Console.WriteLine(tym);
        }
    }
    public bool PridatHraceDoTymu(string prezdivka, string nazevTymu)
    {
        // Vyhledání hráče
        Hrac? hrac = _hraci.Find(h =>
            string.Equals(
                h.Prezdivka,
                prezdivka,
                StringComparison.OrdinalIgnoreCase));

        if (hrac == null)
        {
            Console.WriteLine("Hráč nebyl nalezen.");
            return false;
        }

        // Vyhledání týmu
        Tym? tym = _tymy.Find(t =>
            string.Equals(
                t.Nazev,
                nazevTymu,
                StringComparison.OrdinalIgnoreCase));

        if (tym == null)
        {
            Console.WriteLine("Tým nebyl nalezen.");
            return false;
        }

        // Přidání hráče do týmu
        bool uspech = tym.PridatHrace(hrac);

        if (uspech)
            Console.WriteLine($"Hráč {prezdivka} byl přidán do týmu {nazevTymu}.");

        return uspech;
    }
    public bool OdebratHraceZTymu(string prezdivka, string nazevTymu)
    {
        // Vyhledání hráče
        Hrac? hrac = _hraci.Find(h =>
            string.Equals(
                h.Prezdivka,
                prezdivka,
                StringComparison.OrdinalIgnoreCase));

        if (hrac == null)
        {
            Console.WriteLine("Hráč nebyl nalezen.");
            return false;
        }

        // Vyhledání týmu
        Tym? tym = _tymy.Find(t =>
            string.Equals(
                t.Nazev,
                nazevTymu,
                StringComparison.OrdinalIgnoreCase));

        if (tym == null)
        {
            Console.WriteLine("Tým nebyl nalezen.");
            return false;
        }

        // Odebrání hráče z týmu
        bool uspech = tym.OdebratHrace(hrac);

        if (uspech)
            Console.WriteLine($"Hráč {prezdivka} byl odebrán z týmu {nazevTymu}.");
        else
            Console.WriteLine("Hráč není členem tohoto týmu.");

        return uspech;
    }

}