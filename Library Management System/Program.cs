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
            
            while (true)
            {
                DateTime today = DateTime.Now;
                today = today.AddDays(3);

                var differenceDays = DateTime.Now - today ;

                Console.WriteLine( differenceDays.Days);

                Console.WriteLine("[1.] Administrator ");
                Console.WriteLine("[2.] Czytelnik");
                var operation = Console.ReadKey();
                Console.Clear();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.WriteLine("[1.] Dodaj cztelnika");
                        Console.WriteLine("[2.] Usuń cztelnika");
                        Console.WriteLine("[3.] Dodaj ksiazke do bazy");
                        Console.WriteLine("[4.] Usuń książke z bazy");
                        Console.WriteLine("[5.] Wyświetl wyporzyczone ksiazki");
                        Console.WriteLine("[6.] Wyświetl wszystich czytelników");
                        Console.WriteLine("[7.] Wyporzycz ksiażke");
                        Console.WriteLine("[8.] Zwróć ksiazki");
                        Console.WriteLine("[9.] Wyświetl wszystkie ksiazki");
                        var operation2 = Console.ReadKey();
                        Console.Clear();
                        switch (operation2.KeyChar)
                        {
                            case '1':
                                readerService.addReader();
                                break;
                            case '2':
                                readerService.showReader();
                                Console.WriteLine("Podaj ID czytelnika do usunięcia");
                                var idR = Console.ReadLine();
                                int idReader;
                                Int32.TryParse(idR, out idReader);
                                readerService.removeReader(idReader);
                                break;
                            case '3':
                                bookService.addBook();
                                break;
                            case '4':
                                bookService.showBook();
                                Console.WriteLine("Podaj ID ksiazki do usunięcia");
                                var idB = Console.ReadLine();
                                int idBook;
                                Int32.TryParse(idB, out idBook);
                                bookService.removeBook(idBook);
                                break;
                            case '5':
                                bookService.showBorrowBooks();
                                break;
        
                            case '6':
                                readerService.showReader();
                                break;
                            case '7':
                                readerService.showReader();
                                Console.WriteLine("Podaj ID czytelnika:");
                                var idR2 = Console.ReadLine();
                                int idReader2;
                                Int32.TryParse(idR2, out idReader2);
                                bookService.showBook();
                                Console.WriteLine("Podaj ID ksiazki");
                                var idB2 = Console.ReadLine();
                                int idBook2;
                                Int32.TryParse(idB2, out idBook2);

                                readerService.borrowBook(idReader2, idBook2);
                                break;
                            case '8':
                                readerService.showReader();
                                Console.WriteLine("Podaj ID czytelnika:");
                                var idR3 = Console.ReadLine();
                                int idReader3;
                                Int32.TryParse(idR3, out idReader3);
                                Console.WriteLine("Podaj ID ksiazki");
                                var idB3 = Console.ReadLine();
                                int idBook3;
                                Int32.TryParse(idB3, out idBook3);

                                readerService.returnBook(idReader3, idBook3);
                                break;
                            case '9':
                                bookService.showBook();
                                break;
                        }
                        break;
                    case '2':
                        Console.WriteLine("[1.] Sprawdz wypozyczone ksiazki czytelnika");
                        Console.WriteLine("[2.] Sprawdz dostępne ksiazki");
                        var operation3 = Console.ReadKey();
                        Console.Clear();
                        switch (operation3.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("Podaj swoje ID:");
                                var idR4 = Console.ReadLine();
                                int idReader4;
                                Int32.TryParse(idR4, out idReader4);
                                readerService.showReader(idReader4);
                                break;
                            case '2':
                                Console.WriteLine("Dostępne ksiazki:");
                                bookService.showBook(true);
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