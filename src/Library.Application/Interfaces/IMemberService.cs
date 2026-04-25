using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberResponseDto>> GetAllMembersAsync();
        Task<MemberResponseDto> GetMemberByIdAsync(Guid id);
        Task<MemberResponseDto> CreateMemberAsync(CreateMemberDto dto);
        Task<MemberResponseDto> UpdateMemberAsync(Guid id, CreateMemberDto dto);
        Task DeleteMemberAsync(Guid id);
    }
}