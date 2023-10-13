using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Piszącykodjakis
{
    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w grze!");

        string imie_boh = "";

        while (imie_boh == "")

        {

            Console.WriteLine("Wprowadź imię swojego bohatera");

            imie_boh = Console.ReadLine();

            Console.Clear();
        }


        Console.WriteLine("Wybierz klase postaci");

        Console.WriteLine("Wojownik ---> wpisz '1'");

        Console.WriteLine("Mag ---> wpisz '2'");

        Console.WriteLine("Żul ---> wpisz '3'");

        Console.WriteLine("Demon ---> wpisz '4'");

        int klasa_boh = int.Parse(Console.ReadLine());

        string nazwa_klasy = "";

        // Przypisanie zmiennej bohater obiekty z klasy charakter

        Character bohater;

        switch (klasa_boh)
        {
            case 1:

                bohater = new Player(imie_boh);

                nazwa_klasy = "Wojownik";

                break;

            case 2:

                bohater = new Player(imie_boh);

                nazwa_klasy = "Mag";

                bohater.Health -= 10;

                bohater.Damage += 10;

                break;

            case 3:

                bohater = new Player(imie_boh);

                nazwa_klasy = "żul";

                bohater.Gold = -1;

                bohater.Damage += 20;

                bohater.Health += 50;

                break;

            case 4:

                bohater = new Player(imie_boh);

                nazwa_klasy = "Demon";

                bohater.Health -= 20;
                    
                bohater.Damage += 20;

                break;

            default:

                Console.WriteLine("Nie wybrałeś bohatera :(");

                Console.ReadKey();

                return;
        }
        Console.Clear();

        Console.WriteLine($"Twój bohater to {nazwa_klasy} o imieniu {bohater.Name}.");

        Console.WriteLine($"Ma {bohater.Health} hp i {bohater.Gold} złota.");

        Console.ReadKey();

        Console.Clear();
        // Kilka potrzbenych zmiennych

        bool sklep_otwarty = true;

        int liczba_przeciwnikow = 0;

        int maksymalna_liczba_przeciwnikow = 2;

        int cena_sklepu = 30;

        int zadane_obrazenia = 0;

        // Główna petla gry

        while (true)
        {
            // Warunek ze sklepem

            if (sklep_otwarty && liczba_przeciwnikow == 1)
            {

                Console.Clear();

                Console.WriteLine("Odwiedzasz sklep. Możesz kupić lepszą broń.");

                Console.WriteLine($"Koszt: {cena_sklepu} złota. Posiadasz {bohater.Gold}");

                Console.WriteLine("Czy chcesz kupić nową broń? (Tak - 't', Nie - dowolny klawisz)");

                if (Console.ReadKey().KeyChar == 't')
                {
                    if (bohater.Gold >= cena_sklepu)
                    {
                        Console.Clear();

                        bohater.Damage += new Random().Next(1, 6);

                        bohater.Gold -= cena_sklepu;

                        Console.WriteLine("Kupiłeś nową broń!");

                        Console.WriteLine($"Twój aktualny atak: {bohater.Damage}");
                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine("Nie masz wystarczającej ilości złota!");
                    }
                }

                Console.ReadKey();

                Console.Clear();

            }

            // Warunek z sytemem walki

            if (liczba_przeciwnikow < maksymalna_liczba_przeciwnikow)
            {



                Console.WriteLine($"Spotykasz {liczba_przeciwnikow + 1} przeciwnika!");

                // Przypisanie zmiennej przeciwnik obiekty z klasy Enemy

                Enemy przeciwnik = new Enemy($"Przeciwnik {liczba_przeciwnikow + 1}");

                Console.WriteLine($"Ma {przeciwnik.Health} hp i {przeciwnik.Gold}");

                Console.WriteLine($"Zaczynasz walkę z {przeciwnik.Name}!");


                while (bohater.Health > 0 && przeciwnik.Health > 0)

                {

                    Console.WriteLine("Co chcesz zrobić?");

                    Console.WriteLine("1. Atakuj");

                    Console.WriteLine("2. Użyj umiejętności specjalnej");

                    int wybor_akcji = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (wybor_akcji)
                    {
                        case 1:

                            bohater.Attack(przeciwnik);

                            zadane_obrazenia += bohater.Damage;

                            if (przeciwnik.Health > 0)
                            {
                                Console.WriteLine($"{przeciwnik.Name} atakuje {bohater.Name} za {przeciwnik.Damage} obrażeń.");

                                bohater.Health -= przeciwnik.Damage;
                            }
                            Console.ReadKey();

                            Console.Clear();
                            break;
                        case 2:

                            bohater.UseSpecialAbility(przeciwnik);

                            Console.ReadKey();

                            Console.Clear();

                            break;

                        default:

                            Console.WriteLine("Niepoprawny wybór. Tracisz turę.");

                            break;
                    }
                    Console.WriteLine($"Stan twojego bohatera: | Zdrowie: {bohater.Health} | Złoto: {bohater.Gold}");

                    Console.WriteLine($"Stan przeciwnika: | Zdrowie: {przeciwnik.Health} | Złoto: {przeciwnik.Gold}");

                    Console.ReadKey();

                    Console.Clear();
                }

                // Sprawdzenie hp bohatera

                if (bohater.Health <= 0)
                {
                    Console.WriteLine("Twój bohater zginął. Koniec gry.");

                    break;
                }
                else
                {

                    Console.WriteLine($"Pokonałeś {przeciwnik.Name}! Zdobywasz {przeciwnik.Gold} złota.");

                    bohater.Gold += przeciwnik.Gold;

                    liczba_przeciwnikow++;

                    sklep_otwarty = true;
                }


                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");

                Console.ReadKey();
            }

            // Reszta kodu po zabiciu 2 przeciwnkow

            else
            {

                // Losowanie liczby

                int procent_wygranych = new Random().Next(-20, 130);

                Console.WriteLine("Pokonałeś wszystkich przeciwników! Gratulacje!");

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Co chcesz teraz zrobić?");

                Console.WriteLine("1. Rozwiazac zgadke i miec szanse na pojscie do nieba.");

                Console.WriteLine("2. Iść do piekła");

                int wybor_koncowy = int.Parse(Console.ReadLine());

                Console.ReadKey();

                Console.Clear();

                // wybor jednej z dwoch opcji

                switch (wybor_koncowy)
                {
                    case 1:

                        Console.WriteLine("wybrales zagranie w gre zyc albo nie zyc");

                        Console.WriteLine("musisz zgadnac liczbe od 1 - 50 w max 7 prob");

                        // Stworzenie nowego obiektu random

                        Random random = new Random();

                        // Losowanie liczby z przedziału [1, 50]

                        int wylosowanaLiczba = random.Next(1, 51);

                        int liczbaProb = 0;

                        while (liczbaProb < 7)
                        {

                            Console.Write("Podaj swoją propozycję: ");


                            int liczbaGracza;

                            // Sprawdzenie czy uzytkownik podał poprawna liczbe

                            if (!int.TryParse(Console.ReadLine(), out liczbaGracza) || liczbaGracza < 1 || liczbaGracza > 50)
                            {

                                Console.WriteLine("To nie jest prawidłowa liczba z zakresu 1-50. Spróbuj ponownie.");

                                continue;
                            }

                            liczbaProb++;

                            if (liczbaGracza < wylosowanaLiczba)
                            {
                                Console.WriteLine("Szukana liczba jest większa.");

                                Console.ReadKey();

                                Console.Clear();
                            }


                            else if (liczbaGracza > wylosowanaLiczba)
                            {
                                Console.WriteLine("Szukana liczba jest mniejsza.");

                                Console.ReadKey();

                                Console.Clear();
                            }
                            if (liczbaGracza == wylosowanaLiczba)
                            {
                                Console.WriteLine($"Brawo! Zgadłeś liczbę {wylosowanaLiczba}. Możesz cieszyć się spokojną starością..");

                                Console.ReadKey();

                                Console.Clear();

                                break;
                            }
                        }

                        if (liczbaProb >= 7)
                            Console.WriteLine($"Niestety, nie udało Ci się zgadnąć liczby w 5 próbach. Szukana liczba to: {wylosowanaLiczba}.\n Zostajesz zdezintegrowany na poziomie atomowym.");

                        break;

                    case 2:

                        // klepa pve z bossem

                        Console.WriteLine("Wybrałeś wejście do piekła. Przygotuj się na walkę z bossem!");

                        Character hellBoss = new HellBoss(); 
                        while (bohater.Health > 0 && hellBoss.Health > 0)
                        {
                            Console.WriteLine("Co chcesz zrobić?");

                            Console.WriteLine("1. Atakuj");

                            Console.WriteLine("2. Użyj umiejętności specjalnej");

                            int wybor_akcji = int.Parse(Console.ReadLine());

                            switch (wybor_akcji)
                            {
                                case 1:

                                    bohater.Attack(hellBoss);

                                    if (hellBoss.Health > 0)
                                    {
                                        Console.WriteLine($"{hellBoss.Name} atakuje {bohater.Name} za {hellBoss.Damage} obrażeń.");

                                        bohater.Health -= hellBoss.Damage;
                                    }
                                    break;
                                case 2:
                                    if (hellBoss.Health > 0)
                                    {
                                        bohater.UseSpecialAbility(hellBoss);

                                        bohater.Health -= hellBoss.Damage;
                                    }

                                    break;
                                default:

                                    Console.WriteLine("Niepoprawny wybór. Tracisz turę.");

                                    break;
                            }

                            Console.WriteLine($"Stan twojego bohatera: | Zdrowie: {bohater.Health} | Złoto: {bohater.Gold}");

                            Console.WriteLine($"Stan bossa: | Zdrowie: {hellBoss.Health}");
                        }

                        // Sprawdzenie wyniku walki
                        if (bohater.Health <= 0)
                        {

                            Console.WriteLine("Twój bohater został pokonany przez piekielnego demona. Będziesz cierpiał w piekle przez wieczność.\n Powodzenia.");

                            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");

                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Pokonałeś piekielnego demona! Gratulacje!");
                        }

                        return;

                    default:

                        Console.WriteLine("Niepoprawny wybór. Domyślnie idziesz do piekla.");

                        break;
                }


                // Podsumowanie statystyk z gry

                Console.Clear();

                Console.WriteLine("!! Statystyki twojego WYGARNEGO meczu !! ");

                Console.WriteLine($"[Jesteś w najlepszych {procent_wygranych}% graczy z całego świata]");

                Console.WriteLine($"[Liczba zadanych obrażeń w ciągu gry: {zadane_obrazenia}]");

                Console.WriteLine($"[Liczba złota: {bohater.Gold}]");

                break;
            }
        }

        // Trzymanie uruchomionej konsoli az do nacisniecia przycisku

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");

        Console.ReadKey();
    }
}
