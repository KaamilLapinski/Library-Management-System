using FluentAssertions;
using Library_Management_System.App;
using Library_Management_System.Domain.Entity;
using Xunit;

namespace Library_Management_System.Tests
{
    
    public class BookServiceTests
    {
       [Fact]
       public void AddBookTest()
        {
            //Arrange
            var genre = new Genre();
            genre.Id = 1;
            genre.Name = "Komedia";

            var book = new Book();
            book.Id = 1;
            book.Title = "Tytul";
            book.Author = "Kamil";
            book.Genre = genre;

            var bookService = new BookService();
            //Act
            bookService.AddBook(book);
            var returnItem = bookService.GetElementById(1);
            //Assert
            Assert.Equal(book, returnItem);

        }
        [Fact]
        public void RemoveBookTest() 
        {
            //Arrange
            var genre = new Genre();
            genre.Id = 1;
            genre.Name = "Komedia";

            var book = new Book();
            book.Id = 10;
            book.Title = "Tytul";
            book.Author = "Kamil";
            book.Genre = genre;

            var bookService = new BookService();
            bookService.AddBook(book);
            //Act           
            var returnItem = bookService.RemoveBook(10);             
            //Assert
            returnItem.Should().Be(10);
        }
        [Fact]
        public void ShowBooksTest()
        {
            //Arrange
            var bookService = new BookService();          
            //Act           
            var returnItem = bookService.ShowBooks();
            //Assert
            returnItem.Should().Be(0);
        }
        [Fact]
        public void ShowBooksByAvailabilityTest()
        {
            //Arrange
            var genre = new Genre();
            genre.Id = 1;
            genre.Name = "Komedia";

            var book = new Book();
            book.Id = 1;
            book.Title = "Tytul";
            book.Author = "Kamil";
            book.Genre = genre;

            var bookService = new BookService();
            bookService.AddBook(book);
            //Act
            var returnItem = bookService.ShowBooksByAvailability(true);
            //Assert
            returnItem[0].Should().BeSameAs(book);
            

        }


    }
}
