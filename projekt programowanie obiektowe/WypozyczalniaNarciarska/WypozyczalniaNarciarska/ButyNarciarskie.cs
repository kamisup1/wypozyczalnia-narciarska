using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class ButyNarciarskie : SprzetNarciarski
    {
        private static int ostatnieId = 200;
        private static double CenaWynajmu { get; set; } = 50;
        public int RozmiarButow { get; set; }
        public string KolorButow { get; set; }

        public ButyNarciarskie(int rozmiarButow, string kolorButow) : base(++ostatnieId, "Buty Narciarskie", CenaWynajmu)
        {
            RozmiarButow = rozmiarButow;
            KolorButow = kolorButow;
        }

        public override void WyswietlInformacje()
        {
            Console.WriteLine($"{Nazwa}, Rozmiar: {RozmiarButow}, Kolor: {KolorButow}, Cena: {CenaWynajmu}");
        }

        public static void WyswietlDostepneRozmiaryButow(List<ButyNarciarskie> butyNarciarskies)
        {
            var unikalnyRozmiar = butyNarciarskies.Select(b => b.RozmiarButow).Distinct();
            Console.WriteLine("Dostępne rozmiary butów:");
            foreach (var rozmiar in unikalnyRozmiar)
            {
                Console.WriteLine($"{rozmiar}");
            }
        }

        public static List<ButyNarciarskie> WybierzButyPoRozmiarze(List<ButyNarciarskie> butyNarciarskies)
        {
            Console.WriteLine("Podaj pożądany rozmiar butów:");
            int wybranyRozmiar = Convert.ToInt32(Console.ReadLine());

            return butyNarciarskies.Where(b => b.RozmiarButow == wybranyRozmiar).ToList();
        }

        public static void WyswietlDostepneKoloryNart(List<ButyNarciarskie> buty)
        {
            var unikalnykolor = buty.Select(n => n.KolorButow).Distinct();
            Console.WriteLine("Dostępne kolory butow:");
            foreach (var kolor in unikalnykolor)
            {
                Console.WriteLine($"{kolor}");
            }
        }

        public static List<ButyNarciarskie> WybierzButyKolor(List<ButyNarciarskie> przefiltrowaneButy)
        {
            Console.WriteLine("Podaj kolor butow:");
            string wybranykolor = Console.ReadLine();

            return przefiltrowaneButy
                .Where(n => n.KolorButow.Equals(wybranykolor, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}