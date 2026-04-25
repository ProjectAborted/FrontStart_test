using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    // Data transfer object for book loan
    public class BorrowRequestDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
    }

    // Data transfer object for book return
    public class ReturnRequestDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
    }

    // Response object for the borrowed book
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