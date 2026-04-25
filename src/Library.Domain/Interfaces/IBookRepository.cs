using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();

    // FIX: parameter type changed from int to Guid to match Book.Id
    Task<Book?> GetByIdAsync(Guid id);

    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Guid id);

    // FIX: added missing method — BookService.BorrowBookAsync calls this
    // but it was never declared in the interface or implemented in BookRepository
    Task CreateBorrowRecordAsync(BorrowRecord record);
}