# Esport Tournament System

Konzolová aplikace v jazyce **C#** určená pro správu esportových turnajů. Umožňuje vytvářet hráče a týmy, organizovat turnaje, zaznamenávat výsledky zápasů a zobrazovat průběžné pořadí týmů.

## Funkce aplikace

### Správa hráčů
- Vytváření a mazání hráčů.
- Evidence jména a přezdívky.
- Kontrola duplicitních přezdívek.
- Zobrazení všech registrovaných hráčů.

### Správa týmů
- Vytváření a mazání týmů.
- Přidávání a odebírání hráčů.
- Zobrazení seznamu týmů a jejich hráčů.
- Kontrola, aby hráč nemohl být současně členem více týmů.

### Správa turnajů
- Vytváření více turnajů.
- Přidávání týmů do turnajů.
- Zobrazení týmů jednotlivých turnajů.
- Samostatné statistiky pro každý turnaj.

### Správa zápasů
- Vytváření zápasů mezi týmy daného turnaje.
- Zaznamenávání výsledků.
- Určení vítěze nebo remízy.
- Zobrazení všech zápasů v turnaji.
- Ochrana proti opakovanému zaznamenání výsledku.

### Tabulka turnaje
- Automatické řazení týmů podle získaných bodů.
- Zohlednění rozdílu skóre při shodném počtu bodů.
- Zobrazení výher, remíz, proher a vstřelených a obdržených gólů.

## Bodovací systém

| Výsledek zápasu | Získané body |
|---|---:|
| Výhra | 3 body |
| Remíza | 1 bod |
| Prohra | 0 bodů |

Týmy jsou v tabulce řazeny podle následujících kritérií:

1. Vyšší počet bodů.
2. Vyšší rozdíl skóre (vstřelené góly minus obdržené góly).
3. Abecední pořadí názvu týmu.

## Struktura projektu

| Soubor | Popis |
|---|---|
| `Program.cs` | Hlavní program, menu a uživatelské rozhraní. |
| `Hrac.cs` | Reprezentace hráče a jeho údajů. |
| `Tym.cs` | Reprezentace týmu a správa jeho hráčů. |
| `SpravaHracu.cs` | Evidence a správa hráčů a týmů. |
| `Zapas.cs` | Reprezentace zápasu, jeho výsledku a vítěze. |
| `Turnaj.cs` | Správa turnaje, zápasů, statistik a výsledkové tabulky. |

## Architektura

Aplikace využívá objektově orientovaný přístup a rozděluje jednotlivé části funkcionality do samostatných tříd.

Každý turnaj spravuje vlastní seznam týmů, zápasů a statistik. Jeden tým se proto může účastnit více turnajů, aniž by se jeho statistiky mezi jednotlivými turnaji vzájemně ovlivňovaly.

Hlavní program zajišťuje komunikaci s uživatelem prostřednictvím konzolového menu a využívá jednotlivé třídy pro zpracování operací.

## Požadavky

- Windows, Linux nebo macOS.
- Nainstalovaný .NET SDK kompatibilní s cílovým frameworkem projektu.
- Vývojové prostředí podporující C# (například Visual Studio nebo Visual Studio Code).

## Spuštění aplikace

1. Naklonujte repozitář:

   ```bash
   git clone <URL_REPOZITARE>
   ```

2. Přejděte do složky projektu:

   ```bash
   cd Esport_tournament_system
   ```

3. Spusťte aplikaci:

   ```bash
   dotnet run
   ```

## Použité technologie

- **Programovací jazyk:** C#
- **Platforma:** .NET
- **Typ aplikace:** Konzolová aplikace
- **Správa verzí:** Git a GitHub

---

*Projekt byl vytvořen jako týmová práce v rámci vývoje aplikace pro správu esportových turnajů.*
