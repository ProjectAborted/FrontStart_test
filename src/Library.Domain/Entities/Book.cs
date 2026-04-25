namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        
        public int ISBN { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public bool IsBorrowed => AvailableCopies == 0;
    }
}