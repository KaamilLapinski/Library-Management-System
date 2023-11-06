using Library_Management_System.App.Concrete;
using Library_Management_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Managers
{
    public class GenreManager
    {
        private GenreService _genreService;
        public GenreManager() 
        {
            _genreService = new GenreService();
        }

        public Genre addGenreView()
        {
            Genre genre = new Genre();
            Console.WriteLine("Podaj nazwe kategori");
            var name = Console.ReadLine();

            var lastId = _genreService.GetLastId();
            genre.Id = lastId + 1;
            genre.Name = name;

            return genre;
        } 
    }
}
