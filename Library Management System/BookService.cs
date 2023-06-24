using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class BookService
    {
        public static List<Book> books { get; set; }   
        public BookService() 
        {
            books = new List<Book>();
        }

        public void showBook()
        {      
            foreach (var book in books)
            {              
                if (book.isAvailable == true)
                {
                    Console.WriteLine($"ID: {book.idBook} Tytul: {book.title} Autor: {book.author} Gatunek: {book.genre} Wyporzyczona: Nie");
                }
                else if (book.isAvailable == false)
                {
                    Console.WriteLine($"ID: {book.idBook} Tytul: {book.title} Autor: {book.author} Gatunek: {book.genre} Wyporzyczona: Tak");
                }             
            }
        }
        public void showBook(bool isAvilible)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Aktualnie niema ksiazek do wypożyczenia");
            }
            else
            {
                foreach (var book in books)
                {                
                    if (book.isAvailable == isAvilible)
                    {
                        Console.WriteLine($"ID: {book.idBook} Tytul: {book.title} Autor: {book.author} Gatunek: {book.genre}");
                    }                 
                  }                     
                }
            }
        public void showBorrowBooks()
        {
            foreach (var book in books)
            {
                if(book.isAvailable == false)
                {
                    Console.WriteLine($"ID: {book.idBook} Tytul: {book.title} Autor: {book.author} Gatunek: {book.genre} Dostępność: {book.isAvailable}");
                }
            }
        }
        public void addBook()
        {
            Book book = new Book();

            Console.WriteLine("Podaj ID ksiazki:");
            var id = Console.ReadLine();
            int idBook;
            Int32.TryParse(id, out idBook);

            Console.WriteLine("Podaj tytuł ksiazki:");
            var title = Console.ReadLine();

            Console.WriteLine("Podaj autora:");
            var author = Console.ReadLine();

            Console.WriteLine("Podaj kategorie: ");
            var genre = Console.ReadLine();
            

            book.idBook = idBook;
            book.title = title;
            book.author = author;
            book.genre = genre;

            books.Add(book);
            Console.WriteLine("Dodano ksiazke do bazy");
        }
        public void removeBook(int idBook)
        {
            foreach(var book in books)
            {
                if(book.idBook == idBook)
                {
                    books.Remove(book);
                    break;
                }
            }
            Console.WriteLine("Usunieto ksiazke z bazy");
        }
           
    }
}
