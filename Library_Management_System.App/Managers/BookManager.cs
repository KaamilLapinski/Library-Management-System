using Library_Management_System.App.Concrete;
using Library_Management_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Managers
{
    public class BookManager
    {
        private BookService _bookService;

        public BookManager()
        {
            _bookService = new BookService();
        }
        public Book addBookView()
        {
            
                Book book = new Book();
                Console.WriteLine("Podaj tytuł książki:");
                var title = Console.ReadLine();

                Console.WriteLine("Podaj autora:");
                var author = Console.ReadLine();
              
                bool existGenre;
                if (GenreService.Elements.Count > 0)
                {
                    Console.WriteLine("Podaj kategorie: ");
                    for (int i = 0; i < GenreService.Elements.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}].{GenreService.Elements[i].Name}");
                    }
                    existGenre = true;
                }
                else
                {                    
                    existGenre = false;
                }
                if (existGenre)
                {
                    var idG = Console.ReadLine();
                    int idGenre;
                    Int32.TryParse(idG, out idGenre);
                    book.Genre = GenreService.Elements[idGenre - 1];
                    var lastId = _bookService.GetLastId();
                    book.Id = lastId + 1;
                    book.Name = title;
                    book.Author = author;
                }
                else
                {
                    Genre defaultGenre = new Genre();
                    defaultGenre.Id = 0;
                    defaultGenre.Name = "Brak kategori";

                    book.Genre = defaultGenre;
                    var lastId = _bookService.GetLastId();
                    book.Id = lastId + 1;
                    book.Name = title;
                    book.Author = author;
                }
            
                
                
                

                return book;
            }
            
        }
    }

