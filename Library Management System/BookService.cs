using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class BookService
    {
        public static List<Book> Books { get; set; }   
        public BookService() 
        {
            Books = new List<Book>();
        }

        public void ShowBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Brak ksiażek w bazie.");
            }
            else
            {
                foreach (var book in Books)
                {

                    if (book.IsAvailable == true)
                    {
                        Console.WriteLine($"ID: {book.IdBook} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre} Wypożyczona: Nie");
                    }
                    else if (book.IsAvailable == false)
                    {
                        Console.WriteLine($"ID: {book.IdBook} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre} Wypożyczona: Tak");
                    }
                }
            }
            
        }
        public void ShowBooksByAvailability(bool isAvailable)
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Aktualnie nie ma książek do wypożyczenia");
            }
            else
            {
                foreach (var book in Books)
                {                
                    if (book.IsAvailable == isAvailable)
                    {
                        Console.WriteLine($"ID: {book.IdBook} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre}");
                    }
                    else
                    {
                        Console.WriteLine("Aktualnie brak dostępnych ksiażek.");
                    }
                  }                     
                }
            }
        public void AddBook()
        {
            Book book = new Book();
                     
            Console.WriteLine("Podaj ID książki:");
            int idBook;
            while (!Int32.TryParse(Console.ReadLine(), out idBook))
            {
                Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
            }
            Console.WriteLine("Podaj tytuł książki:");
            var title = Console.ReadLine();

            Console.WriteLine("Podaj autora:");
            var author = Console.ReadLine();

            Console.WriteLine("Podaj kategorie: ");
            var genre = Console.ReadLine();
            
            book.IdBook = idBook;
            book.Title = title;
            book.Author = author;
            book.Genre = genre;

            Books.Add(book);
            Console.WriteLine("Dodano książke do bazy");
        }
        public void removeBook(int idBook)
        {
            foreach(var book in Books)
            {
                if(book.IdBook == idBook)
                {
                    Books.Remove(book);
                    break;
                }
            }
            Console.WriteLine("Usunieto książke z bazy");
        }        
    }
}
