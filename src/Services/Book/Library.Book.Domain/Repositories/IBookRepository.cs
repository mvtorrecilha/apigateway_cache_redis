using Library.Book.Domain.Entities;

namespace Library.Book.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<BookItem>> GetAllBooksAsync();
}
