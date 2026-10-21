using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrailA.Models
{
    [Index(nameof(Email) , IsUnique =true)]
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required , RegularExpression("^(Candidate|Employer|Admin)$")]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public CandidateProfile CandidateProfile { get; set; }
        public ICollection<Company> companies { get; set; } = new List<Company>();

    }
}
