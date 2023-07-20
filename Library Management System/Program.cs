using Library_Management_System.App;

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
            -Dodawanie, usywanie, !edytowanie czytalnika(generowanie ID, imie, nazwisko, telefon, email, (lista ksiazek wypozyczonych, kara))
            -Dodawanie, usywanie, !edytowanie ksiazek(generowanie ID, tytul, autor, cena, kategoria (inforamcja czy jest wypozyczona i do kiedy))
            -Wypozyczenie ksiazki(ID czytalnika, ID ksiazki, czas, czy jest dostepna,)
            - zwrot ksiazki(ID czytalnika, ID ksiazki, informacja ze ksiazka jest dostepna i usuniecie z listy wypozyczony u czytelnika)
            - wyswietlenie listy wszystkich wypozyczonych ksiazek
            -Wyswietlenie wszystkich czytelnikow
            -Wyswietlenie wszytkich ksiazek 

            Czytelnik:
            -Wystwietlenie ksiazek jakie ma wypozyczone, czy ma kare naliczoną, czas do kiedy musi zwrócić ksiązke
            - Wyświetlenie listy wszystkich ksiazek z informacją o wypozyczeniu z mozliwoscia filtracji
            */
            Console.WriteLine("-------------Library Management System-------------");
            ReaderService readerService = new ReaderService();
            BookService bookService = new BookService();
            Genre genre;
            while (true)
            {               
                Console.WriteLine("[1.] Administrator ");
                Console.WriteLine("[2.] Czytelnik");
                var operation = Console.ReadKey();
                Console.Clear();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.WriteLine("[1.] Dodaj czytelnika");
                        Console.WriteLine("[2.] Usuń czytelnika");
                        Console.WriteLine("[3.] Dodaj ksiażke do bazy");
                        Console.WriteLine("[4.] Usuń książke z bazy");
                        Console.WriteLine("[5.] Wyświetl wypożyczone książki");
                        Console.WriteLine("[6.] Wyświetl wszystkich czytelników");
                        Console.WriteLine("[7.] Wypożycz ksiażke");
                        Console.WriteLine("[8.] Zwróć ksiązke");
                        Console.WriteLine("[9.] Wyświetl wszystkie ksiązki");
                        var operation2 = Console.ReadKey();
                        Console.Clear();
                        switch (operation2.KeyChar)
                        {
                            case '1':
                                readerService.AddReader();
                                break;
                            case '2':
                                readerService.ShowReaders();
                                Console.WriteLine("Podaj ID czytelnika do usunięcia");
                                var idR = Console.ReadLine();
                                int idReader;
                                Int32.TryParse(idR, out idReader);
                                readerService.RemoveReader(idReader);
                                break;
                            case '3':
                                bookService.AddBook();
                                break;
                            case '4':
                                bookService.ShowBooks();
                                Console.WriteLine("Podaj ID ksiazki do usunięcia");
                                var idB = Console.ReadLine();
                                int idBook;
                                Int32.TryParse(idB, out idBook);
                                bookService.RemoveBook(idBook);
                                break;
                            case '5':
                                bookService.ShowBooksByAvailability(false);
                                break;
                            case '6':
                                readerService.ShowReaders();
                                break;
                            case '7':
                                readerService.ShowReaders();
                                Console.WriteLine("Podaj ID czytelnika:");                              
                                int idReader2;                               
                                while (!Int32.TryParse(Console.ReadLine(), out idReader2))
                                {
                                    Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
                                };

                                bookService.ShowBooks();
                                Console.WriteLine("Podaj ID książki");
                                int idBook2;
                                while (!Int32.TryParse(Console.ReadLine(), out idBook2))
                                {
                                    Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
                                };

                                readerService.BorrowBook(idReader2, idBook2);
                                break;
                            case '8':
                                readerService.ShowReaders();
                                Console.WriteLine("Podaj ID czytelnika:");
                                int idReader3;
                                while (!Int32.TryParse(Console.ReadLine(), out idReader3))
                                {
                                    Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
                                };
                                
                                Console.WriteLine("Podaj ID książki");
                                int idBook3;    
                                while (!Int32.TryParse(Console.ReadLine(), out idBook3))
                                {
                                    Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
                                };
                                readerService.ReturnBook(idReader3, idBook3);
                                break;
                            case '9':
                                bookService.ShowBooks();
                                break;
                        }
                        break;
                    case '2':
                        Console.WriteLine("[1.] Sprawdz wypożyczone książki czytelnika");
                        Console.WriteLine("[2.] Sprawdz dostępne książki");
                        var operation3 = Console.ReadKey();
                        Console.Clear();
                        switch (operation3.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("Podaj swoje ID:");                               
                                int idReader4; 
                                while (!Int32.TryParse(Console.ReadLine(), out idReader4))
                                {
                                    Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
                                };
                                readerService.ShowReaders(idReader4);
                                break;
                            case '2':
                                Console.WriteLine("Dostępne książki:");
                                bookService.ShowBooksByAvailability(true);
                                break;
                        }
                        break;              
                    default:
                        Console.WriteLine("Wybrana akcja nie istnieje!");
                        break;
                }
            }         
        }
    }
}