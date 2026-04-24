using System;
using Library.Domain.Interfaces;
using Library.Domain.Entities;
using Library.Application.Interfaces;

namespace Library.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
    
    public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null) throw new Exception("Member not found");
            return member;
        }

        public async Task CreateMemberAsync(Member member)
        {
            // Business Rule: Ensure email is unique before adding
            var existing = await _memberRepository.GetByEmailAsync(member.Email);
            if (existing != null) throw new Exception("Email already registered");

            await _memberRepository.AddAsync(member);
        }

    }
}
