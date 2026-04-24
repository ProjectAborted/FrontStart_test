using Library.Domain.Entities;


namespace Library.Application.Interfaces;

public interface IBookService {
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task BorrowBookAsync(int bookId, int memberId);
}
