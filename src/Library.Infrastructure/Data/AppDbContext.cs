using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;

namespace Library.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<BorrowRecord> BorrowRecords => Set<BorrowRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CONCURRENCY: tells EF Core to include RowVersion in every UPDATE WHERE clause.
        // If the row was modified between our read and our write, SaveChanges throws
        // DbUpdateConcurrencyException — preventing AvailableCopies from going negative.
        modelBuilder.Entity<Book>()
            .Property(b => b.RowVersion)
            .IsRowVersion();

        // Ensure email uniqueness at the database level (backs the service-level check)
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Email)
            .IsUnique();
    }
}