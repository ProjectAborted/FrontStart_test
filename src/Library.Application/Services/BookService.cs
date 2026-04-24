using Microsoft.Extensions.Caching.Memory;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;
using Library.Domain.Entities;


namespace Library.Application.Services;

public class BookService : IBookService {
    private readonly IBookRepository _repository;
    private readonly IMemoryCache _cache;

    public BookService(IBookRepository repository, IMemoryCache cache) {
        _repository = repository;
        _cache = cache;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync() 
    {
        // Try to get from cache first (Requirement: Read-heavy Caching)
        return await _cache.GetOrCreateAsync("all_books", async entry => 
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            return await _repository.GetAllAsync();
        }) ?? Enumerable.Empty<Book>();
    }

    public async Task BorrowBookAsync(Guid bookId, Guid memberId) {
        var book = await _repository.GetByIdAsync(bookId);
        
        // Rule: Only borrow if AvailableCopies > 0
        if (book == null || book.AvailableCopies <= 0)
            throw new InvalidOperationException("Book is not available for borrowing.");

        book.AvailableCopies--;
        
        // Create the record and update the book in one transaction
        await _repository.CreateBorrowRecordAsync(new BorrowRecord {
            BookId = bookId,
            MemberId = memberId,
            BorrowDate = DateTime.UtcNow,
            Status = "Borrowed"
        });

        await _repository.UpdateAsync(book);
        _cache.Remove("all_books"); // Invalidate cache after data change
    }
}
