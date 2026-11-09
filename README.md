# 🎮 E-sport turnajový systém

## 📌 O projektu

E-sport turnajový systém je konzolová aplikace vytvořená v jazyce C#. Slouží ke správě herních turnajů, hráčů, týmů a zápasů.
Program umožňuje zapisovat výsledky zápasů, počítat body týmů, zobrazovat turnajovou tabulku a statistiky.

## 🎯 Hlavní funkce

- Přidávání a správa hráčů.
- Vytváření a správa týmů.
- Přidávání hráčů do týmů.
- Vytváření zápasů mezi týmy.
- Zapisování výsledků zápasů.
- Určování vítězů.
- Výpočet bodů týmů.
- Zobrazování turnajové tabulky.
- Výpis statistik týmů.

## 📁 Struktura projektu

EsportTurnaj/
│
├── Program.cs
├── Hrac.cs
├── Tym.cs
├── Zapas.cs
├── Turnaj.cs
├── README.md
└── .gitignore

## 🧱 Třídy v projektu

### Hrac
- Jméno
- Přezdívka
- Přiřazený tým

### Tym
- Název týmu
- Seznam hráčů
- Počet výher
- Počet proher
- Počet bodů

### Zapas
- Domácí tým
- Hostující tým
- Skóre
- Vítěz

### Turnaj
- Seznam týmů
- Seznam zápasů
- Výpočet bodů
- Turnajová tabulka
- Statistiky

## Rozdělení práce v týmu

### Vincent(Správce repozitáře) – Hráči a týmy

**Soubory:** `Hrac.cs`, `Tym.cs`

- Vytváření a správa hráčů.
- Přidávání a mazání hráčů.
- Vytváření a správa týmů.
- Přidávání hráčů do týmů.
- Výpis hráčů a týmů.

### Kryštof(správce dokumentace a testů) – Zápasy

**Soubor:** `Zapas.cs`

- Vytváření zápasů mezi týmy.
- Zapisování výsledků zápasů.
- Určování vítěze zápasu.
- Výpis odehraných zápasů.
- Evidence výher a proher.

### Daniel(správce úkolů) – Turnaj a statistiky 

**Soubor:** `Turnaj.cs`

- Správa turnaje.
- Výpočet bodů týmů.
- Vytváření turnajové tabulky.
- Řazení týmů podle bodů.
- Statistiky a nejlepší týmy.

### Společná práce

- Propojení jednotlivých částí programu.
- Vytvoření hlavního menu v `Program.cs`.
- Testování programu.
- Oprava chyb.
- Spolupráce přes GitHub.

## Bodovací systém

| Výsledek | Body |
|---|---:|
| Výhra | 3 |
| Remíza | 1 |
| Prohra | 0 |

Týmy budou seřazeny podle počtu získaných bodů.
Při shodě bodů rozhodne rozdíl skóre.

## Ukázka hlavního menu

================================
       E-SPORT TURNAJ
================================

1. Správa hráčů
2. Správa týmů
3. Správa zápasů
4. Turnajová tabulka
5. Statistiky
0. Konec

Vyber možnost:

## GitHub a týmová spolupráce

Při práci na projektu budeme používat:

- **Repository** – společné úložiště projektu.
- **Issues** – rozdělení jednotlivých úkolů.
- **Projects / Board** – přehled úkolů.
- **Branches** – samostatné větve pro jednotlivé členy.
- **Commits** – ukládání změn.
- **Pull Requests** – slučování hotových částí projektu.
- **Code Review** – kontrola kódu spolužáky.

### Postup práce

1. Vybereme si Issue.
2. Vytvoříme vlastní větev.
3. Naprogramujeme přidělený úkol.
4. Provedeme commity.
5. Nahrajeme větev na GitHub.
6. Vytvoříme Pull Request.
7. Spolužák zkontroluje náš kód.
8. Po schválení sloučíme změny do hlavní větve.

## Týmová dohoda

1. Každý člen zodpovídá za svou přidělenou část projektu.
2. Změny v hlavní větvi provádíme přes Pull Request.
3. Každý člen pravidelně aktualizuje své Issues.
4. Před sloučením kódu provedeme kontrolu spolužákem.
5. Při problému nebo konfliktu se nejdříve domluvíme společně.

## Možná budoucí vylepšení

- Turnajový pavouk.
- Výběr konkrétní hry (CS2, League of Legends, Valorant).
- Nejlepší hráč turnaje.
- Historie zápasů.
- Ukládání dat do SQLite databáze.
- Grafické uživatelské rozhraní.

## Plán práce

| Fáze | Úkol |
|---|---|
| 1 | Založení projektu a GitHubu |
| 2 | Vytvoření tříd |
| 3 | Programování hráčů a týmů |
| 4 | Programování zápasů |
| 5 | Programování turnajové tabulky |
| 6 | Propojení tříd |
| 7 | Testování a opravy |
| 8 | Dokončení dokumentace a prezentace |
