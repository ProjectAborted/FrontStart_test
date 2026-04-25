namespace Library.Domain.Entities
{
    public class BorrowRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;

        // Nullable: null means the book has not been returned yet
        public DateTime? ReturnDate { get; set; }

        public string Status { get; set; } = "Borrowed";

        // Navigation properties allow EF Core to load related data via .Include()
        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
    }
}