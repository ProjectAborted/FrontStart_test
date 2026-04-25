using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await _context.Books.ToListAsync();

    // FIX: parameter was int — changed to Guid to match Book.Id and IBookRepository
    public async Task<Book?> GetByIdAsync(Guid id) =>
        await _context.Books.FindAsync(id);

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    // FIX: this method was called in BookService.BorrowBookAsync but was never
    // declared in IBookRepository or implemented here — now it is both.
    public async Task CreateBorrowRecordAsync(BorrowRecord record)
    {
        await _context.BorrowRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }
}