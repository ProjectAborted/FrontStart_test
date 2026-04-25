using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    public class CreateMemberDto
    {
        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid address.")]
        public string Email { get; set; } = string.Empty;
    }

    public class MemberResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }
    }
}