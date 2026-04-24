using Microsoft.AspNetCore.Mvc;

using Library.Domain.Entities;
using Library.Application.Interfaces;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase {
        private readonly IBookService _service;

        public BooksController(IBookService service) => _service = service;

        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow(BorrowRequest request) {
            await _service.BorrowBookAsync(request.BookId, request.MemberId);
            return Ok(new { message = "Book borrowed successfully." });
        }
    }

}