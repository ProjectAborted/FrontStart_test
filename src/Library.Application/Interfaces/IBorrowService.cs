using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    // Business logic operations for tracking and retrieving loan transaction history
    public interface IBorrowService
    {
        Task<IEnumerable<BorrowRecordResponseDto>> GetAllRecordsAsync();
        Task<IEnumerable<BorrowRecordResponseDto>> GetMemberHistoryAsync(Guid memberId);
    }
}