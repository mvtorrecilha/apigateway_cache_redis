using Library.Book.Domain.Entities;
using Library.Book.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Book.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("/api/v1/books")]
    public async Task<ActionResult<IEnumerable<BookItem>>> GetAllBooksAsyc()
    {
        var books = await _bookRepository.GetAllBooksAsync();

        return Ok(books);
    }
}
