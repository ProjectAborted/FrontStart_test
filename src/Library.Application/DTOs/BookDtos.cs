using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    // Data transfer object for creating/updating book
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "TotalCopies must be greater than 0.")]
        public int TotalCopies { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableCopies must be >= 0.")]
        public int AvailableCopies { get; set; }
    }

    // Response object for book information previously created/updated
    public class BookResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public bool IsBorrowed { get; set; }
    }
}