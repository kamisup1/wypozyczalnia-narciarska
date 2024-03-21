using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public static class PlikiDane
    {
        public static List<Klient> WczytajKlient(string sciezkaDoPliku)
        {
            List<Klient> klienci = new List<Klient>();
            string[] linie = File.ReadAllLines(sciezkaDoPliku);
            foreach(var linia in linie)
            {
                string[] dane = linia.Split(',');
                Klient klient = new Klient(
               
                    dane[0], // Imie
                    dane[1], // Nazwisko
                    dane[2], // Email
                    dane[3]  // NrTel
                );
                klienci.Add(klient);
            }

            return klienci;
        }


        public static List<Kije> WczytajKije(string sciezkaDoPliku)
        {
            List<Kije> listaKijow = new List<Kije>();
            string[] linie = File.ReadAllLines(sciezkaDoPliku);

            foreach (var linia in linie)
            {
                string[] dane = linia.Split(',');
                Kije kij = new Kije(Convert.ToInt32(dane[0])); // Tworzenie kija z długością z pliku
                listaKijow.Add(kij);

            }

            return listaKijow;
        }

        public static List<ButyNarciarskie> WczytajButyNarciarskie(string sciezkaDoPliku)
        {
            List<ButyNarciarskie> listaButow = new List<ButyNarciarskie>();
            string[] linie = File.ReadAllLines(sciezkaDoPliku);

            foreach (var linia in linie)
            {
                string[] dane = linia.Split(',');
                int rozmiar = Convert.ToInt32(dane[0]);
                string kolor = dane[1];
             

                ButyNarciarskie buty = new ButyNarciarskie(rozmiar, kolor);
                listaButow.Add(buty);
            }

            return listaButow;
        }

        public static List<Narty> WczytajNarty(string sciezkaDoPliku)
        {
            List<Narty> listaNart = new List<Narty>();
            string[] linie = File.ReadAllLines(sciezkaDoPliku);

            foreach (var linia in linie)
            {
                string[] dane = linia.Split(',');
                int dlugosc = Convert.ToInt32(dane[0]);
                string marka = dane[1];


                Narty narty = new Narty(dlugosc, marka);
                listaNart.Add(narty);
            }

            return listaNart;
        }

        public static List<Kaski> WczytajKaski(string sciezkaDoPliku)
        {
            List<Kaski> listaKaskow = new List<Kaski>();
            string[] linie = File.ReadAllLines(sciezkaDoPliku);

            foreach (var linia in linie)
            {
                string[] dane = linia.Split(',');
                string rozmiar = dane[0];
                string kolor = dane[1];


                Kaski kaski = new Kaski(rozmiar, kolor);
                listaKaskow.Add(kaski);
            }

            return listaKaskow;
        }

    }
}