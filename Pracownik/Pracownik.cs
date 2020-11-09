using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Lib
{

    public class Pracownik : IEquatable<Pracownik>, IComparable<Pracownik>
    {   
        
        private string _nazwisko;
        public string Nazwisko 
        {
            get => _nazwisko;
            set => _nazwisko = value.Trim();
        }
        //zaimplementuj obcinanie spacji (trim)
        private DateTime _dataZatrudnienia;

        public DateTime DataZatrudnienia 
        {
            get => _dataZatrudnienia;
            set
            {
                if(DateTime.Compare(value, DateTime.Now) < 0 || DateTime.Compare(value, DateTime.Now) == 0)
                {
                    _dataZatrudnienia = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }
        
        //zaimplementuj: data zatrudnienia nie później niż dzisiaj, w przeciwnym przypadku throw ArgumentException

        private decimal _wyn;
        public decimal Wynagrodzenie
        {
            get => _wyn;
            set => _wyn = (value < 0) ? 0 : value;
            // {
            //     if (value < 0) _wyn = 0;
            //     else _wyn = value;
            // }
        }


        public Pracownik()
        {
            Nazwisko = "Anonim";
            DataZatrudnienia = DateTime.Now;
            Wynagrodzenie = 0;
        }

        public Pracownik(string nazwisko, DateTime dataZatrudnienia, decimal wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }

        public override string ToString() => $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy} ({CzasZatrudnienia}), {Wynagrodzenie} PLN)";

        public bool Equals(Pracownik other)
        {
            if (other is null)
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            if (Nazwisko == other.Nazwisko && DataZatrudnienia == other.DataZatrudnienia && Wynagrodzenie == other.Wynagrodzenie)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public override bool Equals(object obj)
        {
            if (obj is Pracownik)
                return Equals((Pracownik)obj);
            else
                return false;

        }
        public override int GetHashCode()
        {
            return (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();
        }

        public static bool Equals(Pracownik p1, Pracownik p2)
        {
            if ((p1 is null) && (p2 is null))
                return true;
            if (p1 is null)
                return false;
            return p1.Equals(p2);
        }
        public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
        public static bool operator !=(Pracownik p1, Pracownik p2) => !(p1 == p2);

        public int CompareTo(Pracownik other)
        {
            if (other is null) return 1;
            if (this.Equals(other)) return 0;
            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
            if (this.DataZatrudnienia != other.DataZatrudnienia)
                return this.DataZatrudnienia.CompareTo(other.DataZatrudnienia);
            
                return this.Wynagrodzenie.CompareTo(other.Wynagrodzenie);
        }

        public int CzasZatrudnienia
        {
            get => (DateTime.Now - DataZatrudnienia).Days / 30;
        }
    }

    public class WgCzasuZatrudnieniaPotemWgWynagrodzeniaComparer : IComparer<Pracownik>
    {
        public int Compare(Pracownik p1, Pracownik p2)
        {
            if (p1 is null && p2 is null)
                return 0;
            if ((p1 is null) && !(p2 is null))
                return -1;
            if (!(p1 is null) && p2 is null)
                return +1;
            if (p1.CzasZatrudnienia != p2.CzasZatrudnienia)
                return (p1.CzasZatrudnienia.CompareTo(p2.CzasZatrudnienia));
            return p1.Wynagrodzenie.CompareTo(p2.Wynagrodzenie);
        }
    }
    public static class Sortowanie
    {
        public static void SwapElements<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            Contract.Requires(list != null);
            Contract.Requires(firstIndex > 0 && firstIndex < list.Count);
            Contract.Requires(secondIndex > 0 && secondIndex < list.Count);
            if(firstIndex == secondIndex)
            {
                return;
            }
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        public static void Sortuj<T>(this List<T> lista) where T : IComparable<T>
        {
            int n = lista.Count;
            do
            {
                for(int i = 0; i < n - 1; i++)
                {
                    if(lista[i].CompareTo(lista[i + 1]) > 0)
                    {
                        lista.SwapElements(i, i + 1);
                    }
                }
                n--;
            }
            while (n > 1);
        }
        public static void Sortuj<T>(this List<T> lista, IComparer<T> comparer)
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (comparer.Compare(lista[i], lista[i + 1]) > 0)
                    {
                        lista.SwapElements(i, i + 1);

                    }
                }
                n--;
            }
            while (n > 1);
        }

        public static void Sortuj<T>(this List<T> lista, Comparison<T> comparison)
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                   if(comparison(lista[i], lista[i+1]) > 0){

                        lista.SwapElements(i, i + 1);
                   }
                }
                n--;
            }
            while (n > 1);
        }
    }
}
