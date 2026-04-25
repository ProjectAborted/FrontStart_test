using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BorrowRepository : IBorrowRepository
{
    private readonly AppDbContext _context;

    public BorrowRepository(AppDbContext context)
    {
        _context = context;
    }

    // Include navigation properties so BorrowService can read Book.Title and Member.FullName
    public async Task<IEnumerable<BorrowRecord>> GetAllAsync() =>
        await _context.BorrowRecords
            .Include(r => r.Book)
            .Include(r => r.Member)
            .ToListAsync();

    public async Task<IEnumerable<BorrowRecord>> GetByMemberIdAsync(Guid memberId) =>
        await _context.BorrowRecords
            .Include(r => r.Book)
            .Include(r => r.Member)
            .Where(r => r.MemberId == memberId)
            .ToListAsync();

    // Used during return: find the single active record for this book + member pair.
    // If none exists the member is trying to return a book they never borrowed → 400.
    public async Task<BorrowRecord?> GetActiveBorrowAsync(Guid bookId, Guid memberId) =>
        await _context.BorrowRecords
            .FirstOrDefaultAsync(r =>
                r.BookId == memberId &&
                r.MemberId == memberId &&
                r.Status == "Borrowed");

    public async Task AddAsync(BorrowRecord record)
    {
        await _context.BorrowRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BorrowRecord record)
    {
        _context.BorrowRecords.Update(record);
        await _context.SaveChangesAsync();
    }
}