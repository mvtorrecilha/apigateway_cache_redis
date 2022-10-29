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
                Id = Guid.Parse("1673a9fd-191a-479c-a41f-3dc5611aa98e"),
                Author = "Author1",
                Pages = 0,
                Publisher = "",
                Title = "Title1",
            },
            new BookItem
            {
                Id = Guid.Parse("2673a9fd-191a-479c-a41f-3dc5611aa98e"),
                Author = "Author2",
                Pages = 0,
                Publisher = "",
                Title = "Title2",
            }
        };
    }
}
