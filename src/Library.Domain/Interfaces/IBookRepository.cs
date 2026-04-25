using Library.Domain.Entities;


namespace Library.Domain.Interfaces;

public interface IBookRepository {
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(Guid id);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
}

