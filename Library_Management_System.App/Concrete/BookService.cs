﻿using Library_Management_System.App.Common;
using Library_Management_System.Domain;
using Library_Management_System.Domain.Entity;
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
        public void AddBook()
        {
            Book book = new Book();

            Console.WriteLine("Podaj tytuł książki:");
            var title = Console.ReadLine();

            Console.WriteLine("Podaj autora:");
            var author = Console.ReadLine();

            Console.WriteLine("Podaj kategorie: ");
            var genre = Console.ReadLine();
            var lastId = GetLastId();
            book.Id = lastId + 1;
            book.Title = title;
            book.Author = author;
            book.Genre = genre;

            AddElement(book);
            Console.WriteLine("Dodano książke do bazy");
        }
        public void RemoveBook(int idBook)
        {     
            var book = GetElementById(idBook);
            RemoveElement(book);
            
            Console.WriteLine("Usunieto książke z bazy");
        }
        public void ShowBooks()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Brak ksiażek w bazie.");
            }
            else
            {
                foreach (var book in Elements)
                {

                    if (book.IsAvailable == true)
                    {
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre} Wypożyczona: Nie");
                    }
                    else if (book.IsAvailable == false)
                    {
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre} Wypożyczona: Tak");
                    }
                }
                Console.WriteLine("-------");
                GetAllElements();
            }
            
        }
        public void ShowBooksByAvailability(bool isAvailable)
        {
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
                        Console.WriteLine($"ID: {book.Id} Tytul: {book.Title} Autor: {book.Author} Gatunek: {book.Genre}");
                    }
                    else
                    {
                        Console.WriteLine("Aktualnie brak dostępnych ksiażek.");
                    }
                  }                     
                }
            }
          
    }
}