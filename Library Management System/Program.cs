namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Założenia projektowe 
            Program ma wspomagać prace biblioteki.System ma możliwość wypożyczenia
            książki, jej zwrotu oraz sprawdzenia czy książka jest dostępna w danej chwili do wypożyczenia.
            Czytelnicy mą możliwość sprawdzenia informacji o książkach aktualnie wypożyczonych,
            czasie w którym książkę należy zwrócić oraz ew.karze naliczonej za opóźnienie w zwrocie książki.

            Administrator:
            -Dodawanie, usywanie, edytowanie czytalnika(generowanie ID, imie, nazwisko, telefon, email, (lista ksiazek wypozyczonych, kara))
            -Dodawanie, usywanie, edytowanie ksiazek(generowanie ID, tytul, autor, cena, kategoria (inforamcja czy jest wypozyczona i do kiedy))
            -Wypozyczenie ksiazki(ID czytalnika, ID ksiazki, czas, czy jest dostepna,)
            - zwrot ksiazki(ID czytalnika, ID ksiazki, informacja ze ksiazka jest dostepna i usuniecie z listy wypozyczony u czytelnika)
            - wyswietlenie listy wypozyczeń
            -Wyswietlenie wszystkich czytelnikow

            Czytelnik:
            -Wystwietlenie ksiazek jakie ma wypozyczone, czy ma kare naliczoną, czas do kiedy musi zwrócić ksiązke
            - Wyświetlenie listy wszystkich ksiazek z informacją o wypozyczeniu z mozliwoscia filtracji
            */
            Console.WriteLine("-------------Library Management System-------------");
        }
    }
}