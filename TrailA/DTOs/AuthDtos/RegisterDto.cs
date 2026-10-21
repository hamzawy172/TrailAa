using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs.AuthDtos
{
    public class RegisterDto
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, RegularExpression("^(Candidate|Employer|Admin)$")]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
