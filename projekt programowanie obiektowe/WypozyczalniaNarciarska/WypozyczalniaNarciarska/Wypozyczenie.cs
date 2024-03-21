using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Wypozyczenie
    {
        private static int ostatnieIdWypozyczenia = 0;

        public Wypozyczenie(int idKlienta, DateTime dataWynajmuW, DateTime dataZwrotuW)
        {
            IdWypozyczenia = "W" + ++ostatnieIdWypozyczenia;
            IdKlienta = idKlienta;
            DataWynajmuW = dataWynajmuW;
            DataZwrotuW = dataZwrotuW;
            WypozyczonySprzet = new List<SprzetNarciarski>();
            CzyZwrocono = false;
        }

        public string IdWypozyczenia { get; private set; }
        public int IdKlienta { get; private set; }
        public DateTime DataWynajmuW { get; private set; }
        public DateTime DataZwrotuW { get; private set; }
        public List<SprzetNarciarski> WypozyczonySprzet { get; private set; }
        public bool CzyZwrocono { get; private set; }

        public void DodajSprzetDoWypozyczenia(SprzetNarciarski sprzet)
        {
            WypozyczonySprzet.Add(sprzet);
        }

        public void ZwróćSprzęt()
        {
            CzyZwrocono = true;
            // Dodatkowa logika dotycząca zwrotu sprzętu
        }

        public void WyswietlInformacjeOWypozyczeniu()
        {
            Console.WriteLine($"Wypożyczenie ID: {IdWypozyczenia}, Klient ID: {IdKlienta}, Data wynajmu: {DataWynajmuW}, Data zwrotu: {DataZwrotuW}, Czy zwrócono: {CzyZwrocono}");
            foreach (var sprzet in WypozyczonySprzet)
            {
                sprzet.WyswietlInformacje();
            }
        }
    }
}
