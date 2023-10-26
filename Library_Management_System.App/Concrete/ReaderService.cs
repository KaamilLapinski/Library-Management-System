using Library_Management_System.App.Common;
using Library_Management_System.Domain;
using Library_Management_System.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_Management_System.App
{
    public class ReaderService : BaseService<Reader>
    {
        public void AddReader()
        {
            Reader reader = new Reader();
            
            Console.WriteLine("Podaj imie:");
            var name = Console.ReadLine();

            Console.WriteLine("Podaj numer telefonu:");
            var phoneNUmber = Console.ReadLine();

            var lastId = GetLastId();
            reader.Id = lastId + 1;
            reader.Name = name;
            reader.PhoneNumber = phoneNUmber;

            AddElement(reader);
            Console.WriteLine("Dodano nowego czytelnika.");

        }

        public void RemoveReader(int idReader)
        {
            var reader = GetElementById(idReader);
            if(reader.BorrowBooks.Count == 0 && reader != null)
            {
                RemoveElement(reader);
                Console.WriteLine("Usunieto czytelnika.");
            }
            else
            {
                Console.WriteLine("Nie można usunąć czytelnika!");               
            }                       
        }

        public void ShowReaders()
        {           
            foreach (Reader reader in Elements)
            {
                Console.WriteLine($"ID: {reader.Id} Imie: {reader.Name} Numer tel.: {reader.PhoneNumber}");
                if(reader.BorrowBooks.Count > 0)
                {
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.BorrowBooks)
                    {        
                        Console.WriteLine($"ID: {item.Id} Tytul: {item.Name} Autor: {item.Author} Gatunek: {item.Genre.Name}");
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
            foreach(Reader reader in Elements)
            {
                if (reader.Id == id)
                {
                    Console.WriteLine($"ID: {reader.Id} Imie: {reader.Name} Numer tel.: {reader.PhoneNumber}");
                    Console.WriteLine($"Kara: {reader.Penalty} złotych");
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.BorrowBooks)
                    {
                        Console.WriteLine($"ID: {item.Id} Tytuł: {item.Name} Autor: {item.Author} Gatunek: {item.Genre.Name}");
                        Console.WriteLine($"--Książke musisz zwrócić do {item.ReturnDate}");
                    }                   
                }
            }
        }
        public void BorrowBook(int idReader, int idBook)
        {
            foreach (Reader reader in Elements)
            {
                if(reader.Id == idReader)
                {
                    foreach (Book book in BookService.Elements)
                    {
                        if (book.Id == idBook)
                        {
                            if(book.IsAvailable == true)
                            {
                                reader.BorrowBooks.Add(book);
                                book.IsAvailable = false;
                                DateTime today = DateTime.Now;
                                book.ReturnDate = today.AddDays(30);
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
            foreach(Reader reader in Elements)
            {
                if(reader.Id == idReader)
                {
                    foreach(Book book in reader.BorrowBooks)
                    {
                        if(book.Id == idBook && book.IsAvailable == false)
                        {                           
                            var today = DateTime.Now;
                            var differenceDays = today - book.ReturnDate;
                            if(differenceDays.Seconds > 0 )
                            {
                                reader.Penalty += 10;
                                Console.WriteLine($"Naliczona kara za opoznienie: {reader.Penalty} złotych");
                            }
                            if (reader.BorrowBooks.Remove(book))
                            {
                                book.IsAvailable = true;
                                Console.WriteLine("Książka zostałą zwrócona");
                            }
                            else
                            {                               
                                Console.WriteLine("Błąd");
                            }
                            break;
                        }            
                    }
                  break;
                }    
            }          
        }                
    }
}
