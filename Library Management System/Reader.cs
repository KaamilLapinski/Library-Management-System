using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Reader
    {
        // generowanie ID, imie, nazwisko, telefon, email, (lista ksiazek wypozyczonych, kara))
        public int idReader { get; set; }
        public double penalty { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public List<Book> borrowBooks { get; set; }
        
        public Reader() { 
            borrowBooks = new List<Book>();    
            penalty = 0;
        }

    }
}
