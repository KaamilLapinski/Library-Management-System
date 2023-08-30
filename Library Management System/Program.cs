using Library_Management_System;
using Library_Management_System.App;
using Library_Management_System.App.Concrete;
using Library_Management_System.Helpers;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Library Management System-------------");
            ReaderService readerService = new ReaderService();
            BookService bookService = new BookService();
            GenreService genreService = new GenreService();
            
            while (true)
            {               
                Console.WriteLine("[1.] Administrator ");
                Console.WriteLine("[2.] Czytelnik");
                Console.WriteLine("[0.] Wyjście");
                var operation = Console.ReadKey();
                Console.Clear();
                switch (operation.KeyChar)
                {
                    case '1':
                        Console.WriteLine("[1.] Dodaj czytelnika");
                        Console.WriteLine("[2.] Usuń czytelnika");
                        Console.WriteLine("[3.] Dodaj ksiażke do bazy");
                        Console.WriteLine("[4.] Usuń książke z bazy");
                        Console.WriteLine("[5.] Dodaj Kategorie ksiażek");
                        Console.WriteLine("[6.] Wyświetl wypożyczone książki");
                        Console.WriteLine("[7.] Wyświetl wszystkich czytelników");
                        Console.WriteLine("[8.] Wypożycz ksiażke");
                        Console.WriteLine("[9.] Zwróć ksiązke");
                        Console.WriteLine("[10.] Wyświetl wszystkie ksiązki");
                        Console.WriteLine("[0.] Wyjście");
                        var operation2 = Console.ReadLine();
                        Console.Clear();
                        switch (operation2)
                        {
                            case "1":
                                readerService.AddReader();
                                break;
                            case "2":
                                readerService.ShowReaders();
                                Console.WriteLine("Podaj ID czytelnika do usunięcia");
                                var idR = Console.ReadLine();
                                int idReader;
                                Int32.TryParse(idR, out idReader);
                                readerService.RemoveReader(idReader);
                                break;
                            case "3":
                                var book = bookService.addBookView();
                                bookService.AddBook(book);
                                break;
                            case "4":
                                bookService.ShowBooks();
                                Console.WriteLine("Podaj ID ksiazki do usunięcia");
                                var idB = Console.ReadLine();
                                int idBook;
                                Int32.TryParse(idB, out idBook);
                                bookService.RemoveBook(idBook);
                                break;
                            case "5":
                                genreService.AddGenre();
                                break;
                            case "6":
                                bookService.ShowBooksByAvailability(false);
                                break;
                            case "7":
                                readerService.ShowReaders();
                                break;
                            case "8":
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
                            case "9":
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
                            case "10":
                                bookService.ShowBooks();
                                break;

                            case "0":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("\nWybrana akcja nie istnieje");                               
                                Console.ReadKey();
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
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wybrana akcja nie istnieje!");
                        break;
                }
            }         
        }
    }
}