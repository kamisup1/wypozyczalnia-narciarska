using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Kaski : SprzetNarciarski
    {

        private static int ostatnieId = 300;

        private static double CenaWynajmu = 20;
        public string RozmiarKasku { get; set; }
        public string KolorKasku { get; set; }

        public Kaski(string rozmiarKasku, string kolorKasku) : base(++ostatnieId, "Kask", CenaWynajmu)
        {
            RozmiarKasku = rozmiarKasku;
            KolorKasku = kolorKasku;
        }

        public override void WyswietlInformacje()
        {
            Console.WriteLine($"{Nazwa}, Rozmiar: {RozmiarKasku}, Kolor: {KolorKasku}, Cena: {CenaWynajmu} zł");
        }

       
        public static void WyswietlRozmiaryKaskow(List<Kaski> kaski)
        {
            var unikalnyrozmiar = kaski.Select(n => n.RozmiarKasku).Distinct();
            Console.WriteLine("Dostępne rozkiary kasków:");
            foreach (var rozmiar in unikalnyrozmiar)
            {
                Console.WriteLine($"{rozmiar}");
            }
        }

        public static List<Kaski> WybierzRozmiarKasku(List<Kaski> kaski)
        {
            Console.WriteLine("Podaj rozmiar kasku:");
            string wybranyRozmiar =Console.ReadLine();

            var przefiltrowaneKaski = kaski.Where(k => k.RozmiarKasku.Equals(wybranyRozmiar, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!przefiltrowaneKaski.Any())
            {
                Console.WriteLine("Nie znaleziono kasków w wybranym rozmiarze.");
                return new List<Kaski>();
            }
            return przefiltrowaneKaski;
        }

        public static void WyswietlDostepnKoloryKaskow(List<Kaski> kaski)
        {
            var unikalnykolor = kaski.Select(n => n.KolorKasku).Distinct();
            Console.WriteLine("Dostępne kolory kasków:");
            foreach (var kolor in unikalnykolor)
            {
                Console.WriteLine($"{kolor}");
            }
        }

        public static List<Kaski> WybierzKaskKolor(List<Kaski> przefiltrowaneKaski)
        {
            Console.WriteLine("Podaj kolor kasku:");
            string wybranyKolor = Console.ReadLine();

            var wybraneKaski = przefiltrowaneKaski
                .Where(k => k.KolorKasku.Equals(wybranyKolor, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (!wybraneKaski.Any())
            {
                Console.WriteLine("Nie znaleziono kasków w wybranym kolorze.");
            }
            return wybraneKaski;
        }
    }
}
