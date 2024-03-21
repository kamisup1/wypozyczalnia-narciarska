using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Klient
    {
        private static int ostatnieId = 0; // Statyczna zmienna do śledzenia ostatniego ID

        public int IdKlienta { get; private set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string NrTel { get; set; }


        public Klient(string imie, string nazwisko, string email, string nrTel) //jak jest ta zmainna statyczna to  nie mozna tu na poczatku w nawiasie zostawic int id 
        {
            IdKlienta = ++ostatnieId;  //zeby automatycznie zwiaekszalo ++ i zmienna statyczna 
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            NrTel = nrTel;
        }


       
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Klient: {IdKlienta} {Imie} {Nazwisko}, Email: {Email}, Tel: {NrTel}");
        }


    }
}
