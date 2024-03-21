using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Narty : SprzetNarciarski
    {
        private static int ostatnieId = 0;

        private static double CenaWynajmu = 100;

        public int DlugoscNart { get; set; }
        public string MarkaNart { get; set; }

        public Narty(int dlugoscNart, string markaNart) : base(++ostatnieId, "Narty", CenaWynajmu)
        {
            DlugoscNart = dlugoscNart;
            MarkaNart = markaNart;

        }

        public override void WyswietlInformacje()
        {
            Console.WriteLine($"{Nazwa}, Długość: {DlugoscNart} cm, Marka: {MarkaNart} Cena wynajmu: {CenaWynajmu} zł");
        }
       
        public static void WyswietlDostepneDlugosciNart(List<Narty> narty)
        {
            var unikalnaDlugosc = narty.Select(n => n.DlugoscNart).Distinct();
            Console.WriteLine("Dostępne długości nart:");
            foreach (var dlugosc in unikalnaDlugosc)
            {
                Console.WriteLine($"{dlugosc} cm");
            }
        }

        public static List<Narty> WybierzNartyPoDlugosci(List<Narty> narty)
        {
            Console.WriteLine("Podaj pożądana długość nart:");
            int wybranaDlugosc = Convert.ToInt32(Console.ReadLine());

            return narty.Where(n => n.DlugoscNart == wybranaDlugosc).ToList();
        }

        public static void WyswietlDostepneMarkiNart(List<Narty> narty)
        {
            var unikalnaMarka = narty.Select(n => n.MarkaNart).Distinct();
            Console.WriteLine("Dostępne Marki nart:");
            foreach (var marka in unikalnaMarka)
            {
                Console.WriteLine($"{marka}");
            }
        }

        public static List<Narty> WybierzNartyMarka(List<Narty> przefiltrowaneNarty)
        {
            Console.WriteLine("Podaj marke nart:");
            string wybranaMarka = Console.ReadLine();

            return przefiltrowaneNarty
                .Where(n => n.MarkaNart.Equals(wybranaMarka, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}

