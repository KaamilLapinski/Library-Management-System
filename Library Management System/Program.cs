using Library_Management_System.App;
using Library_Management_System.App.Concrete;
using Library_Management_System.App.Managers;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Library Management System-------------");
            ReaderService readerService = new ReaderService();
            ReaderManager readerManager = new ReaderManager();  
            BookService bookService = new BookService();
            BookManager bookManager = new BookManager();
            GenreService genreService = new GenreService();
            GenreManager genreManager = new GenreManager();

            readerService.loadDataFromFile("readers");
            bookService.loadDataFromFile("books");
            genreService.loadDataFromFile("genre");
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
                                readerService.AddReader(readerManager.addReaderView());
                                break;
                            case "2":
                                readerService.RemoveReader(readerManager.getIdReader(false));
                                break;
                            case "3":
                                bookService.AddBook(bookManager.addBookView());
                                break;
                            case "4":
                                bookService.RemoveBook(bookManager.getIdBook());
                                break;
                            case "5":                               
                                genreService.AddGenre(genreManager.addGenreView());
                                break;
                            case "6":
                                bookService.ShowBooksByAvailability(false);
                                break;
                            case "7":
                                readerService.ShowReaders();
                                break;
                            case "8":                              
                                readerService.BorrowBook(readerManager.getIdReader(false), bookManager.getIdBook());
                                break;
                            case "9":
                                readerService.ReturnBook(readerManager.getIdReader(false), bookManager.getIdBook());
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
                                readerService.ShowReaders(readerManager.getIdReader(true));
                                break;
                            case '2':
                                Console.WriteLine("Dostępne książki:");
                                bookService.ShowBooksByAvailability(true);
                                break;
                        }
                        break;
                    case '0':
                        readerService.saveDataToFile("readers");
                        bookService.saveDataToFile("books");
                        genreService.saveDataToFile("genre");
                        Console.WriteLine("Do zobaczenia");
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