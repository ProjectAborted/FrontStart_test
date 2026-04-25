using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Library.Infrastructure.Repositories;


public class BookRepository(AppDbContext context) : IBookRepository {
    public async Task<IEnumerable<Book>> GetAllAsync() => await context.Books.ToListAsync();
    public async Task<Book?> GetByIdAsync(int id) => await context.Books.FindAsync(id);
    public async Task AddAsync(Book book) { await context.Books.AddAsync(book); await context.SaveChangesAsync(); }
    public async Task UpdateAsync(Book book) { context.Books.Update(book); await context.SaveChangesAsync(); }
}
