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
        public List<Reader> readers { get; set; }
        
        public ReaderService()
        {
            readers = new List<Reader>();
                 
        }
        public void addReader()
        {
            Reader reader = new Reader();
            Console.WriteLine("Podaj ID czytelnika:");
            var id = Console.ReadLine();
            int idReader;
            Int32.TryParse(id, out idReader);

            Console.WriteLine("Podaj imie:");
            var name = Console.ReadLine();

            Console.WriteLine("Podaj numer telefonu:");
            var phoneNUmber = Console.ReadLine();

            reader.idReader = idReader;
            reader.name = name;
            reader.phoneNumber = phoneNUmber;

            readers.Add(reader);
            Console.WriteLine("Dodano nowego czytelnika.");
        }
        public void removeReader(int idReader)
        {
            foreach (Reader reader in readers)
            {
                if(reader.idReader == idReader)
                {
                    if(reader.borrowBooks.Count == 0)
                    {
                        readers.Remove(reader);
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
        public void showReader()
        {           
            foreach (Reader reader in readers)
            {
                Console.WriteLine($"ID: {reader.idReader} Imie: {reader.name} Numer tel.: {reader.phoneNumber}");
                if(reader.borrowBooks.Count > 0)
                {
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.borrowBooks)
                    {        
                        Console.WriteLine($"ID: {item.idBook} Tytul: {item.title} Autor: {item.author} Gatunek: {item.genre}");
                    }
                }
                else
                {
                    Console.WriteLine("Czytelnik nie ma wypożyczonych książek.");
                }    
                Console.WriteLine("------------------");
            }
        }
        public void showReader(int id)
        {
            foreach(Reader reader in readers)
            {
                if (reader.idReader == id)
                {
                    Console.WriteLine($"ID: {reader.idReader} Imie: {reader.name} Numer tel.: {reader.phoneNumber}");
                    Console.WriteLine($"Kara: {reader.penalty} złotych");
                    Console.WriteLine("Wypożyczone książki:");
                    foreach (var item in reader.borrowBooks)
                    {
                        Console.WriteLine($"ID: {item.idBook} Tytuł: {item.title} Autor: {item.author} Gatunek: {item.genre}");
                        Console.WriteLine($"--Książke musisz zwrócić do {item.returnDate}");
                    }
                }
            }
        }

        public void borrowBook(int idReader, int idBook)
        {
            foreach (Reader reader in readers)
            {
                if(reader.idReader == idReader)
                {
                    foreach (Book book in BookService.books)
                    {
                        if (book.idBook == idBook)
                        {
                            if(book.isAvailable == true)
                            {
                                reader.borrowBooks.Add(book);
                                book.isAvailable = false;
                                DateTime today = DateTime.Now;
                                book.returnDate = today.AddSeconds(10);
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
        public void returnBook(int idReader, int idBook)
        {
            foreach(Reader reader in readers)
            {
                if(reader.idReader == idReader)
                {
                    foreach(Book book in BookService.books)
                    {
                        if(book.idBook == idBook && book.isAvailable == false)
                        {                           
                            var today = DateTime.Now;
                            var differenceDays = today - book.returnDate;
                            if(differenceDays.Seconds > 0 )
                            {
                                reader.penalty += 10;
                                Console.WriteLine($"Naliczona kara za opoznienie: {reader.penalty} złotych");
                            }
                            reader.borrowBooks.Remove(book);
                            book.isAvailable = true;                          
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
