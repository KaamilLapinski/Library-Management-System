using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Abstract
{
    public interface IService<T>
    {
        static List<T> Elements { get; set; }

        List<T> GetAllElements();
        void AddElement(T item);
        void RemoveElement(T item);
    }
}
