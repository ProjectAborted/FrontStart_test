using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(Guid id);
        Task CreateMemberAsync(Member member);
    }
}