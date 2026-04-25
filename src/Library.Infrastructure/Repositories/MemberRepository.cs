using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class MemberRepository(AppDbContext context) : IMemberRepository
{
    public async Task<IEnumerable<Member>> GetAllAsync() => await context.Members.ToListAsync();
    
    public async Task<Member?> GetByIdAsync(Guid id) => await context.Members.FindAsync(id);

    public async Task<Member?> GetByEmailAsync(string email) => 
        await context.Members.FirstOrDefaultAsync(m => m.Email == email);

    public async Task AddAsync(Member member)
    {
        await context.Members.AddAsync(member);
        await context.SaveChangesAsync();
    }
}
