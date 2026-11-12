namespace Esport_tournament_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpravaHracu sprava = new SpravaHracu();

            sprava.VytvoritHrace("Vincent", "Vince");
            sprava.VytvoritHrace("Kryštof", "Kris");

            sprava.VytvoritTym("Team Alpha");

            // Přiřazení hráčů
            sprava.PridatHraceDoTymu("Vince", "Team Alpha");
            sprava.PridatHraceDoTymu("Kris", "Team Alpha");

            // Výpis
            sprava.VypsatVsechnyHrace();

            // Odebrání hráče
            sprava.OdebratHraceZTymu("Kris", "Team Alpha");

            // Opětovný výpis
            sprava.VypsatVsechnyHrace();
        }
    }
}
