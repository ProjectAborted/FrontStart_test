using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;

namespace Library.Application.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;

        public BorrowService(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public async Task<IEnumerable<BorrowRecordResponseDto>> GetAllRecordsAsync()
        {
            var records = await _borrowRepository.GetAllAsync();
            return records.Select(MapToDto);
        }

        public async Task<IEnumerable<BorrowRecordResponseDto>> GetMemberHistoryAsync(Guid memberId)
        {
            var records = await _borrowRepository.GetByMemberIdAsync(memberId);
            return records.Select(MapToDto);
        }

        private static BorrowRecordResponseDto MapToDto(Domain.Entities.BorrowRecord r) => new()
        {
            Id = r.Id,
            BookId = r.BookId,
            BookTitle = r.Book?.Title ?? string.Empty,
            MemberId = r.MemberId,
            MemberName = r.Member?.FullName ?? string.Empty,
            BorrowDate = r.BorrowDate,
            ReturnDate = r.ReturnDate,
            Status = r.Status
        };
    }
}