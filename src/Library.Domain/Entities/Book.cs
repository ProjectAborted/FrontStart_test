namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        // FIX: ISBN must be string — ISBNs can have hyphens and leading zeros
        // e.g. "978-3-16-148410-0". Using int would corrupt valid ISBN values.
        public string ISBN { get; set; } = string.Empty;

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        // Computed: true only when ALL copies are borrowed
        public bool IsBorrowed => AvailableCopies == 0;

        // Concurrency token — EF Core uses this to detect conflicting updates.
        // If two requests read AvailableCopies = 1 and both try to decrement,
        // only the first SaveChanges will succeed; the second throws DbUpdateConcurrencyException.
        [System.ComponentModel.DataAnnotations.Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}