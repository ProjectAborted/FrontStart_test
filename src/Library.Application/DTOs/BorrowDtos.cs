using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    // FIX: BorrowRequest was referenced in BooksController but never defined anywhere.
    // Both IDs must be Guid to match Book.Id and Member.Id.
    public class BorrowRequestDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
    }

    public class ReturnRequestDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
    }

    public class BorrowRecordResponseDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public Guid MemberId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}