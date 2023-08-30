using Library_Management_System.App.Common;
using Library_Management_System.App.Concrete;
using Library_Management_System.Domain;
using Library_Management_System.Domain.Entity;
//using Library_Management_System.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System.App
{

    public class BookService : BaseService<Book>
    {
        public Book addBookView()
        {
            Book book = new Book();
            Console.WriteLine("Podaj tytuł książki:");
            var title = Console.ReadLine();

            Console.WriteLine("Podaj autora:");
            var author = Console.ReadLine();

            Console.WriteLine("Podaj kategorie: ");
            if (GenreService.Elements.Count > 0)
            {
                for (int i = 0; i < GenreService.Elements.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}].{GenreService.Elements[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("Brak kategori!");
            }

            var idG = Console.ReadLine();
            int idGenre;
            Int32.TryParse(idG, out idGenre);

            var lastId = GetLastId();
            book.Id = lastId + 1;
            book.Title = title;
            book.Author = author;
            book.Genre = GenreService.Elements[idGenre - 1];

            return book;
        }
        public int AddBook(Book book)
        {
            AddElement(book);
            Console.WriteLine("Dodano książke do bazy");    
            return book.Id;
        }
        public int RemoveBook(int idBook)
        {     
            var book = GetElementById(idBook);
            RemoveElement(book);
            
            Console.WriteLine("Usunieto książke z bazy");
            return book.Id;
        }
        public int ShowBooks()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Brak ksiażek w bazie.");
                return 0;
            }
            else
            {
                foreach (var book in Elements)
                {

                    if (book.IsAvailable == true)
                    {
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre.Name} Wypożyczona: Nie");
                    }
                    else if (book.IsAvailable == false)
                    {
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre.Name} Wypożyczona: Tak");
                    }
                }              
            }
            return 1;
        }
        public List<Book> ShowBooksByAvailability(bool isAvailable)
        {
            List<Book> books = new List<Book>();

            if (Elements.Count == 0)
            {
                Console.WriteLine("Aktualnie nie ma książek do wypożyczenia");
            }
            else
            {
                foreach (var book in Elements)
                {                
                    if (book.IsAvailable == isAvailable)
                    {
                        books.Add(book);
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre}");                       
                    }
                    else
                    {
                        Console.WriteLine("Aktualnie brak dostępnych ksiażek.");
                    }
                  }                     
                }
            return books;
        } 
         
    }
}
