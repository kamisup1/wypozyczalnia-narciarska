using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaNarciarska
{
    public abstract class SprzetNarciarski
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public double CenaWynajmu { get; set; }

        protected SprzetNarciarski(int id, string nazwa, double cenaWynajmu)
        {
            Id = id;
            Nazwa = nazwa;
            CenaWynajmu = cenaWynajmu;
        }

        public abstract void WyswietlInformacje();
    }
}
