using System;
using System.Collections.Generic;
using System.Linq;
using Lib;


namespace Implementacja_interfejsow
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sprawdzenie();
            //Krok2();
            //Krok3();
            Krok4();
            


        }

        static void Krok4()
        {
            var Pracownicy = new List<Pracownik>();
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2020, 10, 01), 1000));
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2018, 11, 05), 2000));
            Pracownicy.Add(new Pracownik("Nowak", new DateTime(2019, 12, 07), 3000));
            Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2019, 12, 07), 2500));
            Pracownicy.Add(new Pracownik("Nowakowski", new DateTime(2020, 09, 01), 3000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 2000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 3000));
            Console.WriteLine();
            var PracownicyWgWynagrodzeniaNazwiska = Pracownicy.OrderBy(x => x.Wynagrodzenie).ThenByDescending(x => x.Nazwisko);
            Console.WriteLine("--- Porządkowanie za pomocą metod rozszerzających Linq" + Environment.NewLine
                        + "kolejno: rosnąco według wynagrodzenia, " + Environment.NewLine
                        + "później malejąco według nazwiska");
            foreach (var pracownik in PracownicyWgWynagrodzeniaNazwiska)
            {
                Console.WriteLine(pracownik);
            }
        }
        static void Krok3()
        {
            var Pracownicy = new List<Pracownik>();
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2020, 10, 01), 1000));
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2018, 11, 05), 2000));
            Pracownicy.Add(new Pracownik("Nowak", new DateTime(2019, 12, 07), 3000));
            Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2019, 12, 07), 2500));
            Pracownicy.Add(new Pracownik("Nowakowski", new DateTime(2020, 09, 01), 3000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 2000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 3000));
            Console.WriteLine(Pracownicy);
            Console.WriteLine("------- Przed sortowaniem -------");
            foreach (var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }
            Console.WriteLine();
            Console.WriteLine("------- Po sortowaniu -------");
            Pracownicy.Sort(new WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer());
            foreach (var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }
            Console.WriteLine();
            Console.WriteLine("--- Zewnętrzny porządek - delegat typu Comparison" + Environment.NewLine
                        + "najpierw według czasu zatrudnienia (w miesiącach), " + Environment.NewLine
                        + "a później kolejno według nazwiska i wynagrodzenia - wszystko rosnąco");
            Pracownicy.Sort((p1, p2) => (p1.CzasZatrudnienia.ToString("D3") + p1.Nazwisko + p1.Wynagrodzenie.ToString("00000.00")).CompareTo(p2.CzasZatrudnienia.ToString("D3") + p2.Nazwisko + p2.Wynagrodzenie.ToString("00000.00")));
            foreach(var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }
            Console.WriteLine();
            Console.WriteLine("--- Zewnętrzny porządek - delegat typu Comparison" + Environment.NewLine
                        + "kolejno: malejąco według wynagrodzenia, " + Environment.NewLine
                        + "później rosnąca według czasu zatrudnienia");
            Pracownicy.Sort((p1, p2) => ((p1.Wynagrodzenie != p2.Wynagrodzenie) ? (-1) * p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie) : p1.CzasZatrudnienia.CompareTo(p2.CzasZatrudnienia)));
            foreach(var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }
        }
        static void Krok2()
        {
            var Pracownicy = new List<Pracownik>();
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2020, 10, 01), 1000));
            Pracownicy.Add(new Pracownik("Jania", new DateTime(2018, 11, 05), 2000));
            Pracownicy.Add(new Pracownik("Nowak", new DateTime(2019, 12, 07), 3000));
            Pracownicy.Add(new Pracownik("Kowalski", new DateTime(2019, 12, 07), 2500));
            Pracownicy.Add(new Pracownik("Nowakowski", new DateTime(2020, 09, 01), 3000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 2000));
            Pracownicy.Add(new Pracownik("Abacki", new DateTime(2017, 06, 22), 3000));
            Console.WriteLine(Pracownicy);
            Console.WriteLine("------- Przed sortowaniem -------");
            foreach (var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }
            Console.WriteLine();
            Console.WriteLine(string.Join('\n', Pracownicy));
            Console.WriteLine();
            Pracownicy.Sort();
            Console.WriteLine("------- Po sortowaniu -------");
            foreach (var pracownik in Pracownicy)
            {
                Console.WriteLine(pracownik);
            }

        }
        static void Sprawdzenie()
        {
            Console.WriteLine("--- Sprawdzenie poprawności tworzenia obiektu ---");
            Pracownik p = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
            Console.WriteLine(p);

            Console.WriteLine("--- Sprawdzenie równości obiektów ---");
            Pracownik p1 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
            Pracownik p2 = new Pracownik("Nowak", new DateTime(2010, 10, 1), 1_000);
            Pracownik p3 = new Pracownik("Kowalski", new DateTime(2010, 10, 1), 1_000);
            Pracownik p4 = p1;

            Console.WriteLine($"p1: {p1} hashCode: {p1.GetHashCode()}");
            Console.WriteLine($"p2: {p2} hashCode: {p2.GetHashCode()}");
            Console.WriteLine($"p3: {p3} hashCode: {p3.GetHashCode()}");
            Console.WriteLine($"p4: {p4} hashCode: {p4.GetHashCode()}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p2 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p2): {Object.ReferenceEquals(p1, p2)}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1 == p2: {p1 == p2}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p3 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p3): {Object.ReferenceEquals(p1, p3)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine($"p1 == p3: {p1 == p3}");
            Console.WriteLine();

            Console.WriteLine($"--- Równość dla p1 oraz p4 -");
            Console.WriteLine($"Object.ReferenceEquals(p1, p4): {Object.ReferenceEquals(p1, p4)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p4)}");
            Console.WriteLine($"p1 == p4: {p1 == p4}");
        }
    }
}
