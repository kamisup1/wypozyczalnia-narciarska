using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Kije : SprzetNarciarski

    {

        private static int ostatnieId = 100;
        private static double CenaWynajmu { get; set; } = 34;

        public int DlugoscKijow { get; set; }

        public Kije(int dlugoscKijkow) : base(++ostatnieId, "Kije", CenaWynajmu)
        {
            DlugoscKijow = dlugoscKijkow;
        }

        public override void WyswietlInformacje()
        {
            Console.WriteLine($"Kije: {Nazwa}, Długość: {DlugoscKijow} cm, Cena wynajmu: {CenaWynajmu} zł");
        }

        public static void WyswietlDostepneDlugosciKijow(List<Kije> kije)
        {
            var unikalneDlugosci = kije.Select(k => k.DlugoscKijow).Distinct();
            Console.WriteLine("Dostępne długości kijków:");
            foreach (var dlugosc in unikalneDlugosci)
            {
                Console.WriteLine($"{dlugosc} cm");
            }
        }

        public static List<Kije> WybierzKijePoDlugosci(List<Kije> kije)
        {
            Console.WriteLine("Podaj pożądaną długość kijków (w cm):");
            int wybranaDlugosc = Convert.ToInt32(Console.ReadLine());

            return kije.Where(k => k.DlugoscKijow == wybranaDlugosc).ToList();
        }
    }
}
