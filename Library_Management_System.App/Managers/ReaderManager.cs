using Library_Management_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Managers
{
    public class ReaderManager
    {
        private ReaderService _readerService;
        public ReaderManager()
        {
            _readerService = new ReaderService();
        }

        public Reader addReaderView()
        {
            Reader reader = new Reader();

            Console.WriteLine("Podaj imie:");
            var name = Console.ReadLine();

            Console.WriteLine("Podaj numer telefonu:");
            var phoneNUmber = Console.ReadLine();

            var lastId = _readerService.GetLastId();
            reader.Id = lastId + 1;
            reader.Name = name;
            reader.PhoneNumber = phoneNUmber;

            return reader;
        }

        public int getIdReader(bool onlyOne )
        {
            if (!onlyOne) { _readerService.ShowReaders(); }
            Console.WriteLine("Podaj ID czytelnika:");
            int idReader;
            while (!Int32.TryParse(Console.ReadLine(), out idReader))
            {
                Console.WriteLine("Nie prawidłowe dane! Podaj liczbe:");
            };
            return idReader;
        }
    }
}
