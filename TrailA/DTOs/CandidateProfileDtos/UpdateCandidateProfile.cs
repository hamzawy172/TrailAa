using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrailA.Models;

namespace TrailA.DTOs.CandidateProfileDtos
{
    public class UpdateCandidateProfile
    {
        [Required, Phone]
        public string Phone { get; set; }
        public string? ResumeUrl { get; set; }
        [Required, MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int YearsOfExperince { get; set; }
        public int UserId { get; set; }

    }
}
