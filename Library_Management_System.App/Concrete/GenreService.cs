﻿using Library_Management_System.App.Common;
using Library_Management_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Concrete
{
    public class GenreService : BaseService<Genre>
    {
        public void AddGenre(Genre genre)
        {
            AddElement(genre);
            Console.WriteLine("Dodano nową kategorie.");
        }
        public void RemoveGenre(int genreId)
        {
            var genre = GetElementById(genreId);
            if (genre != null)
            {
                RemoveElement(genre);
            }
            else 
            {
                Console.WriteLine("Kategoria o podanym id nie istnieje!");
            }        
        }

        public void ShowGenre()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("Brak kategori w bazie");
            }
            else
            {
                foreach (Genre genre in Elements)
                {
                    Console.WriteLine($"ID: [{genre.Id}] - {genre.Name} ");
                }
            }
        }
    }
}
