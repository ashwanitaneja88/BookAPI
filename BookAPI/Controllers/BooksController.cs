using BookAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult Books()
        {
           return Ok(_bookRepository.GetBooks());

        }
        [HttpGet("{id}")]
        public IActionResult BookById(int id)
        {
            _logger.Log(LogLevel.Information, "BookById is called", id);
            var book = _bookRepository.GetBookById(id);
            return  (book == null) ? NoContent(): Ok(book);
        } 

        [HttpPost]
        public IActionResult SaveBooks(Book book)
        {
            _logger.Log(LogLevel.Information, "PostBooks is called", book);

            if (!ModelState.IsValid)
            {
                _logger.Log(LogLevel.Error, "data is invalid", book);
                return BadRequest(ModelState);
            }
            return Ok(_bookRepository.SaveBook(book));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            _logger.Log(LogLevel.Information, "update book is called", book);
            if (!ModelState.IsValid)
            {
                _logger.Log(LogLevel.Error, "data is invalid", book);
                return BadRequest(ModelState);
            }
            if (id != book.Id)
            {
                return BadRequest();
            }
            var result = _bookRepository.UpdateBook(id, book);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.Log(LogLevel.Information, "delete book is called", id);
            var result = _bookRepository.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}