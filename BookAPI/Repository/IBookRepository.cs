namespace BookAPI.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        bool SaveBook(Book book);
        bool UpdateBook(int id, Book book);
        bool Delete(int id);
    }
}
