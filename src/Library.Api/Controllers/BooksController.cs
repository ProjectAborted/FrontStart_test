using Microsoft.AspNetCore.Mvc;
using Library.Application.DTOs;
using Library.Application.Interfaces;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    // FIX: Controller now depends on IBookService only — no business logic lives here.
    // All rules (copies check, cache, concurrency) are enforced in BookService.
    private readonly IBookService _service;

    public BooksController(IBookService service) => _service = service;

    // GET /api/books — returns cached list on subsequent calls
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _service.GetAllBooksAsync();
        return Ok(books);
    }

    // GET /api/books/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await _service.GetBookByIdAsync(id);
        return Ok(book);    // NotFoundException handled by ExceptionMiddleware → 404
    }

    // POST /api/books → 201 Created
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto dto)
    {
        var created = await _service.CreateBookAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /api/books/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, CreateBookDto dto)
    {
        var updated = await _service.UpdateBookAsync(id, dto);
        return Ok(updated);
    }

    // DELETE /api/books/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteBookAsync(id);
        return NoContent();
    }

    // POST /api/books/borrow
    // FIX: BorrowRequest was never defined — replaced with BorrowRequestDto (Guid fields)
    [HttpPost("borrow")]
    public async Task<IActionResult> Borrow(BorrowRequestDto request)
    {
        await _service.BorrowBookAsync(request);
        return Ok(new { message = "Book borrowed successfully." });
    }

    // POST /api/books/return
    [HttpPost("return")]
    public async Task<IActionResult> Return(ReturnRequestDto request)
    {
        await _service.ReturnBookAsync(request);
        return Ok(new { message = "Book returned successfully." });
    }
}