using Library_Management_System.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Domain.Entity
{
    public class Reader : BaseEntity
    {
        public double Penalty { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Book> BorrowBooks { get; set; }
        
        public Reader() { 
            BorrowBooks = new List<Book>();    
            Penalty = 0;
        }
    }
}
