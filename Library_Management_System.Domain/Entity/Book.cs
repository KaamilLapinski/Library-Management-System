using Library_Management_System.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Domain.Entity
{
    public class Book : BaseEntity
    {
        //generowanie ID, tytul, autor, cena, kategoria (inforamcja czy jest wypozyczona i do kiedy)

        //public int IdBook { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }

        public DateTime ReturnDate { get; set; }

        public Book()
        {           
            IsAvailable = true;             
        }    
    }
}
