using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Implementacja_interfejsow
{
    public class Pracownik
    {
        private string nazwisko;
        private DateTime dataZatrudnienia;
        private decimal wynagrodzenie;
        //DateTime x = new DateTime;

        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko.Trim();
        }
        public DateTime DataZatrudnienia
        {   
            get => dataZatrudnienia;
            
        }
    }
}
