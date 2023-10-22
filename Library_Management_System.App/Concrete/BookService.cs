using Library_Management_System.App.Common;
using Library_Management_System.App.Concrete;
using Library_Management_System.Domain;
using Library_Management_System.Domain.Entity;
using Newtonsoft.Json;
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
        public int AddBook(Book book)
        {
            AddElement(book);
            Console.WriteLine("Dodano książke do bazy");    
            return book.Id;
        }

        public int RemoveBook(int idBook)
        {     
            var book = GetElementById(idBook);
            if (book != null)
            {
                RemoveElement(book);

                Console.WriteLine("Usunieto książke z bazy");
                return book.Id;

            }
            else
            {
                Console.WriteLine("Ksiazka o podanym id nie istnieje!");
                return 0;
            }
            
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
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Name} Autor: {book.Author} Gatunek: {book.Genre.Name} Wypożyczona: Nie");
                    }
                    else if (book.IsAvailable == false)
                    {
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Name} Autor: {book.Author} Gatunek: {book.Genre.Name} Wypożyczona: Tak");
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
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Name} Autor: {book.Author} Gatunek: {book.Genre}");                       
                    }
                    else
                    {
                        Console.WriteLine("Aktualnie brak dostępnych ksiażek.");
                    }
                  }                     
                }
            return books;
        }
      /*
        public void loadReadersFromFile()
        {
            string json = File.ReadAllText(@"C:\Users\klapi\Documents\Dane_Library\readers.json");
            var readers = JsonConvert.DeserializeObject<List<Reader>>(json);
            Elements = readers;
        }
      */
    }
}
