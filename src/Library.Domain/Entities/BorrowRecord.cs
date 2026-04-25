using System;

namespace Library.Domain.Entities
{
    public class BorrowRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; } // Nullable because it hasn't been returned yet
        public string Status { get; set; } = "Borrowed"; 

        // Navigation Properties (Optional but highly recommended)
        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
    }
}
