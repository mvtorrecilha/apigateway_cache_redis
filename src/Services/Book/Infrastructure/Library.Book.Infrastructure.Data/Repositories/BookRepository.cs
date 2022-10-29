using Library.Book.Domain.Entities;
using Library.Book.Domain.Repositories;

namespace Library.Book.Infrastructure.Data.Repositories;

public class BookRepository : IBookRepository
{
    public BookRepository()
    {
    }

    public async Task<IEnumerable<BookItem>> GetAllBooksAsync()
    {
        return new List<BookItem>
        {
            new BookItem
            {
                Id = new Guid(),
                Author = "Author1",
                Pages = 0,
                Publisher = "",
                Title = "Title1",
            },
            new BookItem
            {
                Id = new Guid(),
                Author = "Author2",
                Pages = 0,
                Publisher = "",
                Title = "Title2",
            }
        };
    }
}
