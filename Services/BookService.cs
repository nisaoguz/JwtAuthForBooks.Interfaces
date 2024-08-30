

using System.Linq;
using JwtAuthForBooks.Models;

public class BookService 
{
    private readonly YourDbContext _dbContext;

    public BookService(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<BookInformations> GetAllBooks()
    {
        return _dbContext.BookInformations;
    }

    public BookInformations GetBookById(int id)
    {
        return _dbContext.BookInformations.FirstOrDefault(book => book.BookId == id);
    }

    public void AddBook(BookInformations book)
    {
        _dbContext.BookInformations.Add(book);
        _dbContext.SaveChanges();
    }

    public void UpdateBook(BookInformations book)
    {
        _dbContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteBook(int id)
    {
        var book = _dbContext.BookInformations.FirstOrDefault(b => b.BookId == id);
        if (book != null)
        {
            _dbContext.BookInformations.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}


