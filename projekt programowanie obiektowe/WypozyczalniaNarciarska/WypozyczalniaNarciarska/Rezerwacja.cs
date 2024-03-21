using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public class Rezerwacja
    {
        private static int ostatnieIdRezerwacji = 0;

        public string IdRezerwacji { get; private set; }
        public int IdKlienta { get; set; }
        public DateTime DataWynajmuR { get; set; }
        public DateTime DataZwrotuR { get; set; }
        public List<SprzetNarciarski> ZarezerwowanySprzet { get; private set; }


        public Rezerwacja(int idKlienta, DateTime dataWynajmuR, DateTime dataZwrotuR)
        {
            IdRezerwacji = "R" + ++ostatnieIdRezerwacji;
            IdKlienta = idKlienta;
            DataWynajmuR = dataWynajmuR;
            DataZwrotuR = dataZwrotuR;
            ZarezerwowanySprzet = new List<SprzetNarciarski>();
        }

        public void DodajSprzetDoRezerwacji(SprzetNarciarski sprzet)
        {
            ZarezerwowanySprzet.Add(sprzet);
        }

        public void WyswietlInformacjeORezerwacji()
        {
            Console.WriteLine($"Rezerwacja ID: {IdRezerwacji}, Klient ID: {IdKlienta}, Data wynajmu: {DataWynajmuR}, Data zwrotu: {DataZwrotuR}");
            foreach (var sprzet in ZarezerwowanySprzet)
            {
                sprzet.WyswietlInformacje();
            }
        }



    }
}
