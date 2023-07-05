using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_Management_System
{
    public class ReaderService
    {
        public List<Reader> Readers { get; set; }
        
        public ReaderService()
        {
            Readers = new List<Reader>();                
        }
        public void AddReader()
        {
            Reader reader = new Reader();
            Console.WriteLine("Podaj ID czytelnika:");           
            int idReader;
            while(!Int32.TryParse(Console.ReadLine(), out idReader))
            {
                Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
            };
            Console.WriteLine("Podaj imie:");
            var name = Console.ReadLine();

            Console.WriteLine("Podaj numer telefonu:");
            var phoneNUmber = Console.ReadLine();

            reader.IdReader = idReader;
            reader.Name = name;
            reader.PhoneNumber = phoneNUmber;

            Readers.Add(reader);
            Console.WriteLine("Dodano nowego czytelnika.");
        }
        public void RemoveReader(int idReader)
        {
            foreach (Reader reader in Readers)
            {
                if(reader.IdReader == idReader)
                {
                    if(reader.BorrowBooks.Count == 0)
                    {
                        Readers.Remove(reader);
                        Console.WriteLine("Usunieto czytelnika.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie można usunąć czytelnika, który ma wypożyczone książki.");
                        break;
                    }                   
                }
            }          
        }
        public void ShowReaders()
        {           
            foreach (Reader reader in Readers)
            {
                Console.WriteLine($"ID: {reader.IdReader} Imie: {reader.Name} Numer tel.: {reader.PhoneNumber}");
                if(reader.BorrowBooks.Count > 0)
                {
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.BorrowBooks)
                    {        
                        Console.WriteLine($"ID: {item.IdBook} Tytul: {item.Title} Autor: {item.Author} Gatunek: {item.Genre}");
                    }
                }
                else
                {
                    Console.WriteLine("Czytelnik nie ma wypożyczonych książek.");
                }    
                Console.WriteLine("------------------");
            }
        }
        public void ShowReaders(int id)
        {
            foreach(Reader reader in Readers)
            {
                if (reader.IdReader == id)
                {
                    Console.WriteLine($"ID: {reader.IdReader} Imie: {reader.Name} Numer tel.: {reader.PhoneNumber}");
                    Console.WriteLine($"Kara: {reader.Penalty} złotych");
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.BorrowBooks)
                    {
                        Console.WriteLine($"ID: {item.IdBook} Tytuł: {item.Title} Autor: {item.Author} Gatunek: {item.Genre}");
                        Console.WriteLine($"--Książke musisz zwrócić do {item.ReturnDate}");
                    }
                }
            }
        }
        public void BorrowBook(int idReader, int idBook)
        {
            foreach (Reader reader in Readers)
            {
                if(reader.IdReader == idReader)
                {
                    foreach (Book book in BookService.Books)
                    {
                        if (book.IdBook == idBook)
                        {
                            if(book.IsAvailable == true)
                            {
                                reader.BorrowBooks.Add(book);
                                book.IsAvailable = false;
                                DateTime today = DateTime.Now;
                                book.ReturnDate = today.AddSeconds(10);
                                Console.WriteLine("Książka została wypożyczona");
                            }
                            else
                            {
                                Console.WriteLine("Nie można wypożyczyć tej książki.");
                            }         
                            break;
                        }                       
                    }                                  
                    break;
                }
            }
        }
        public void ReturnBook(int idReader, int idBook)
        {
            foreach(Reader reader in Readers)
            {
                if(reader.IdReader == idReader)
                {
                    foreach(Book book in BookService.Books)
                    {
                        if(book.IdBook == idBook && book.IsAvailable == false)
                        {                           
                            var today = DateTime.Now;
                            var differenceDays = today - book.ReturnDate;
                            if(differenceDays.Seconds > 0 )
                            {
                                reader.Penalty += 10;
                                Console.WriteLine($"Naliczona kara za opoznienie: {reader.Penalty} złotych");
                            }
                            reader.BorrowBooks.Remove(book);
                            book.IsAvailable = true;                          
                            Console.WriteLine("Książka zostałą zwróćona");
                            break;
                        }            
                    }
                  break;
                }    
            }          
        }                 
    }
}
