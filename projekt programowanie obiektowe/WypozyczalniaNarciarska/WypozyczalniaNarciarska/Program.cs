using System;
using System.Collections.Generic;
using System.Linq;

namespace WypozyczalniaNarciarska
{
    class Program
    {
        static List<Rezerwacja> rezerwacje = new List<Rezerwacja>();
        static List<Wypozyczenie> wypozyczenia = new List<Wypozyczenie>();

        static void Main(string[] args)
        {
            var klienci = PlikiDane.WczytajKlient("C:\\Users\\kamis\\OneDrive\\Pulpit\\projekt programowanie obiektowe\\tekstowe\\Klienci2.txt");
            var kije = PlikiDane.WczytajKije("C:\\Users\\kamis\\OneDrive\\Pulpit\\projekt programowanie obiektowe\\tekstowe\\Kije2.txt");
            var buty = PlikiDane.WczytajButyNarciarskie("C:\\Users\\kamis\\OneDrive\\Pulpit\\projekt programowanie obiektowe\\tekstowe\\Buty.txt");
            var narty = PlikiDane.WczytajNarty("C:\\Users\\kamis\\OneDrive\\Pulpit\\projekt programowanie obiektowe\\tekstowe\\Narty.txt");
            var kaski = PlikiDane.WczytajKaski("C:\\Users\\kamis\\OneDrive\\Pulpit\\projekt programowanie obiektowe\\tekstowe\\Kaski.txt");



            Console.WriteLine("Witaj w wypożyczalni narciarskiej!");

            Klient znalezionyKlient = ZnajdzKlienta(klienci);
            if (znalezionyKlient == null)
            {
                Console.WriteLine("Nie znaleziono klienta.");
                return;
            }


            Console.WriteLine("Chcesz zarezerwować czy wypożyczyć sprzęt? (wpisz 'rezerwacja' lub 'wypozyczenie')");
            string akcja = Console.ReadLine().ToLower();

            Console.WriteLine("Wpisz, co chcesz wynająć (dostępne opcje: 'kije', 'buty', 'narty', 'kaski'):");
            string wybor = Console.ReadLine().ToLower();

            List<SprzetNarciarski> wybranySprzet = WybierzSprzet(wybor, znalezionyKlient, kije, buty, narty, kaski);

            if (akcja == "rezerwacja")
            {
                ZarezerwujSprzet(znalezionyKlient, wybranySprzet);
            }
            else if (akcja == "wypozyczenie")
            {
                WypozyczSprzet(znalezionyKlient, wybranySprzet);
            }
            else
            {
                Console.WriteLine("Nie rozpoznano akcji. Program zostanie zakończony.");
            }
        }

        

        static Klient ZnajdzKlienta(List<Klient> klienci)
        {
            Console.WriteLine("Podaj swoje imię:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj swoje nazwisko:");
            string nazwisko = Console.ReadLine();

            return klienci.FirstOrDefault(k => k.Imie == imie && k.Nazwisko == nazwisko);
        }

        static List<SprzetNarciarski> ObslugaWynajmuKijkow(Klient znalezionyKlient, List<Kije> kije)
        {
            Kije.WyswietlDostepneDlugosciKijow(kije);
            var wybraneKije = Kije.WybierzKijePoDlugosci(kije);
            return wybraneKije.Cast<SprzetNarciarski>().ToList();
        }

        static List<SprzetNarciarski> ObslugaWynajmuButow(Klient znalezionyKlient, List<ButyNarciarskie> buty)
        {

            ButyNarciarskie.WyswietlDostepneRozmiaryButow(buty);
            var WybierzButyPoRozmiarze = ButyNarciarskie.WybierzButyPoRozmiarze(buty);

            ButyNarciarskie.WyswietlDostepneKoloryNart(WybierzButyPoRozmiarze);
            var wybraneButypoKolorze = ButyNarciarskie.WybierzButyKolor(WybierzButyPoRozmiarze);

            return wybraneButypoKolorze.Cast<SprzetNarciarski>().ToList();
        }

        static List<SprzetNarciarski> ObslugaWynajmuNart(Klient znalezionyKlient, List<Narty> narty)
        {
            Narty.WyswietlDostepneDlugosciNart(narty);
            var wybraneNartyPoDlugosci = Narty.WybierzNartyPoDlugosci(narty);

            Narty.WyswietlDostepneMarkiNart(wybraneNartyPoDlugosci);
            var wybraneNartyPoMarce = Narty.WybierzNartyMarka(wybraneNartyPoDlugosci);


            return wybraneNartyPoMarce.Cast<SprzetNarciarski>().ToList();
        }






        static List<SprzetNarciarski> ObslugaWynajmuKaskow(Klient znalezionyKlient, List<Kaski> kaski)
        {
            Kaski.WyswietlRozmiaryKaskow(kaski);
            var wybraneKaskiRozmiar = Kaski.WybierzRozmiarKasku(kaski);

            Kaski.WyswietlDostepnKoloryKaskow(wybraneKaskiRozmiar);
            var wybraneKaskiKolor = Kaski.WybierzKaskKolor(wybraneKaskiRozmiar);


            return wybraneKaskiKolor.Cast<SprzetNarciarski>().ToList();
        }






        static void ObslugaRezerwacji(Klient klient, List<Kije> kije, List<ButyNarciarskie> buty, List<Narty> narty, List<Kaski> kaski)
        {
            Console.WriteLine("Wpisz, co chcesz zarezerwować (dostępne opcje: 'kije', 'buty', 'narty', 'kaski'):");
            string wybor = Console.ReadLine().ToLower();
            List<SprzetNarciarski> wybranySprzet = WybierzSprzet(wybor, klient, kije, buty, narty, kaski);
            ZarezerwujSprzet(klient, wybranySprzet);
        }
        static void ZarezerwujSprzet(Klient znalezionyKlient, List<SprzetNarciarski> sprzetDoWynajecia)
        {
            Console.WriteLine("Podaj datę wypożyczenia (format: RRRR-MM-DD):");
            DateTime dataWynajmu = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Podaj datę zwrotu (format: RRRR-MM-DD):");
            DateTime dataZwrotu = DateTime.Parse(Console.ReadLine());

            var rezerwacja = new Rezerwacja(znalezionyKlient.IdKlienta, dataWynajmu, dataZwrotu);
            foreach (var sprzet in sprzetDoWynajecia)
            {

                rezerwacja.DodajSprzetDoRezerwacji(sprzet);
                
            }

            rezerwacje.Add(rezerwacja);

            WyswietlPodsumowanieRezerwacji(rezerwacja);


        }

        static void WyswietlPodsumowanieRezerwacji(Rezerwacja rezerwacja)  
        {
            Console.WriteLine("\nPodsumowanie Twojej rezerwacji:");
            foreach (var sprzet in rezerwacja.ZarezerwowanySprzet)
            {
                sprzet.WyswietlInformacje();  // Wyświetla informacje o każdym przedmiocie w rezerwacji
            }

            double cenaCalkowita = WyliczCene(rezerwacja);
            Console.WriteLine($"Całkowita cena do zapłaty za wypożyczenie na {LiczbaDniWynajmu(rezerwacja)} dni: {cenaCalkowita} zł");
        }

        static double WyliczCene(Rezerwacja rezerwacja)
        {
            int liczbaDniWynajmu = LiczbaDniWynajmu(rezerwacja);
            return rezerwacja.ZarezerwowanySprzet.Sum(sprzet => sprzet.CenaWynajmu * liczbaDniWynajmu);
        }

        static int LiczbaDniWynajmu(Rezerwacja rezerwacja)
        {
            return (rezerwacja.DataZwrotuR - rezerwacja.DataWynajmuR).Days;
        }



        static void ObslugaWypozyczenia(Klient klient, List<Kije> kije, List<ButyNarciarskie> buty, List<Narty> narty, List<Kaski> kaski)
        {
            Console.WriteLine("Wpisz, co chcesz wypożyczyć (dostępne opcje: 'kije', 'buty', 'narty', 'kaski'):");
            string wybor = Console.ReadLine().ToLower();
            List<SprzetNarciarski> wybranySprzet = WybierzSprzet(wybor, klient, kije, buty, narty, kaski);
            WypozyczSprzet(klient, wybranySprzet);
        }




        static void WypozyczSprzet(Klient znalezionyKlient, List<SprzetNarciarski> sprzetDoWypozyczenia)
        {
            Console.WriteLine("Podaj datę wypożyczenia (format: RRRR-MM-DD):");
            DateTime dataWynajmu = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Podaj datę zwrotu (format: RRRR-MM-DD):");
            DateTime dataZwrotu = DateTime.Parse(Console.ReadLine());

            var wypozyczenie = new Wypozyczenie(znalezionyKlient.IdKlienta, dataWynajmu, dataZwrotu);
            foreach (var sprzet in sprzetDoWypozyczenia)
            {

                wypozyczenie.DodajSprzetDoWypozyczenia(sprzet);

            }

            wypozyczenia.Add(wypozyczenie);

            WyswietlPodsumowanieWypozyczenia(wypozyczenie);


        }

        static void WyswietlPodsumowanieWypozyczenia(Wypozyczenie wypozyczenie)
        {
            Console.WriteLine("\nPodsumowanie Twojego wypozyczenia:");
            foreach (var sprzet in wypozyczenie.WypozyczonySprzet)
            {
                sprzet.WyswietlInformacje();  // Wyświetla informacje o każdym przedmiocie w rezerwacji
            }

            double cenaCalkowita = WyliczCene(wypozyczenie);
            Console.WriteLine($"Całkowita cena do zapłaty za wypożyczenie na {LiczbaDniWynajmu(wypozyczenie)} dni: {cenaCalkowita} zł");
        }

        static double WyliczCene(Wypozyczenie wypozyczenie)
        {
            int liczbaDniWynajmu = LiczbaDniWynajmu(wypozyczenie);
            return wypozyczenie.WypozyczonySprzet.Sum(sprzet => sprzet.CenaWynajmu * liczbaDniWynajmu);
        }

        static int LiczbaDniWynajmu(Wypozyczenie wypozyczenie)
        {
            return (wypozyczenie.DataZwrotuW - wypozyczenie.DataWynajmuW).Days;
        }

        static List<SprzetNarciarski> WybierzSprzet(string wybor, Klient znalezionyKlient, List<Kije> kije, List<ButyNarciarskie> buty, List<Narty> narty, List<Kaski> kaski)
        {
            List<SprzetNarciarski> wybranySprzet = new List<SprzetNarciarski>();
            string[] wybraneOpcje = wybor.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string opcja in wybraneOpcje)
            {
                switch (opcja)
                {
                    case "kije":
                        wybranySprzet.AddRange(ObslugaWynajmuKijkow(znalezionyKlient, kije));
                        break;
                    case "buty":
                        wybranySprzet.AddRange(ObslugaWynajmuButow(znalezionyKlient, buty));
                        break;
                    case "narty":
                        wybranySprzet.AddRange(ObslugaWynajmuNart(znalezionyKlient, narty));
                        break;
                    case "kaski":
                        wybranySprzet.AddRange(ObslugaWynajmuKaskow(znalezionyKlient, kaski));
                        break;
                    default:
                        Console.WriteLine($"Nie znaleziono opcji: {opcja}");
                        break;
                }
            }

            return wybranySprzet;
        }

    }
}
