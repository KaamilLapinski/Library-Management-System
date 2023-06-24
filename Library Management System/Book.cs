using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book
    {
        //generowanie ID, tytul, autor, cena, kategoria (inforamcja czy jest wypozyczona i do kiedy)

        public int idBook { get; set; }
        public double price { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public bool isAvailable { get; set; }

        public DateTime returnDate { get; set; }

        public Book()
        {           
            isAvailable = true;   
            
        }
         
       
    }
}
