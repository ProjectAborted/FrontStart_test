using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOs
{
    // Data transfer object for registering/updating member details
    public class CreateMemberDto
    {
        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid address.")]
        public string Email { get; set; } = string.Empty;
    }

    // Response object containing public member information
    public class MemberResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }
    }
}