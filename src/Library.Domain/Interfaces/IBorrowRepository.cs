using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBorrowRepository
    {
        Task<IEnumerable<BorrowRecord>> GetAllAsync();
        Task<IEnumerable<BorrowRecord>> GetByMemberIdAsync(Guid memberId);

        // Used during return: find the active "Borrowed" record for this book+member
        Task<BorrowRecord?> GetActiveBorrowAsync(Guid bookId, Guid memberId);

        Task AddAsync(BorrowRecord record);
        Task UpdateAsync(BorrowRecord record);
    }
}