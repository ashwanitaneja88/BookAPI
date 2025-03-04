using BookAPI.Controllers;
using BookAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using System.Net;
using System.Windows.Input;

namespace BookAPI.UnitTests
{
    [TestFixture]
    public class BooksControllerUnitTest
    {
        private readonly Mock<ILogger<BooksController>> _logger = new Mock<ILogger<BooksController>>();
        public Mock<IBookRepository> _bookRepository;
        public BooksControllerUnitTest()
        { }
        private static List<Book> books = new()
            {
            new Book(  1,"ASP.NET","ASP.Net Core with .Net 8","Donald Macwilth",1000)
            };

        [SetUp]
        public void Setup()
        {

            _bookRepository = new Mock<IBookRepository>();
            _bookRepository.Setup(x => x.GetBooks()).Returns(books);
            _bookRepository.Setup(x => x.GetBookById(1)).Returns(books.First());
            _bookRepository.Setup(x => x.SaveBook(books.First())).Returns(true);
            _bookRepository.Setup(x => x.UpdateBook(1, books.First())).Returns(true);
            _bookRepository.Setup(x => x.Delete(1)).Returns(true);
        }

        [Test]
        public void Books_BooksReturnedResults()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            IActionResult result = book.Books();
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Books_BooksReturnedResultsById()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            IActionResult result = book.BookById(1);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Books_BooksNoReturnedResultsById()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.BookById(2);
            var noContentResult = result as NoContentResult;
            Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
        }
        [Test]
        public void Books_SaveBooks()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.SaveBooks(new Book(1, "T", "T", "T", 10000));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Books_UpdateBooks()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.UpdateBook(1, books.First());
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void Books_UpdateBooks_InvalidRequest()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.UpdateBook(1, new Book(2, "Test Name", "Test Desc", "Test Author", 10000));
            var badRequestResult = result as BadRequestResult;
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }
        [Test]
        public void Books_DeleteBooks()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.Delete(1);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void Books_DeleteBooks_InvalidRequest()
        {
            BooksController book = new BooksController(_logger.Object, _bookRepository.Object);
            var result = book.Delete(5);
            var badRequestResult = result as BadRequestResult;
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }
    }
}