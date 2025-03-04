using System.Security.Principal;

namespace BookAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new()
        {
         new(
                1,
                "ASP.NET",
                "ASP.Net Core with .Net 8",
                "Donald Macwilth",
                 1000
         ),
         new(
                 2,
                 "ML.NET",
                "Machine learning with .NET",
                "Arthur Warne",
                 5000
         ),
            new(
                 3,
                "Java",
                "Java spring",
                "Shane Andrew",
                 3000
         )
        };
        public List<Book> GetBooks() => books;

        public Book GetBookById(int id) => books.FirstOrDefault(x => x.Id == id);

        public bool SaveBook(Book book)
        {
            books.Add(book);
            return true;
        }

        public bool UpdateBook(int id, Book book)
        {
            var BookToBeUpdated = books.FirstOrDefault(x => x.Id == id);
            if (BookToBeUpdated != null)
            {
                books.Remove(BookToBeUpdated);
                books.Add(book);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var customerToUpdate = books.FirstOrDefault(x => x.Id == id);
            if (customerToUpdate != null)
            {
                books.Remove(customerToUpdate);
                return true;
            }
            return false;
        }
    }
}
