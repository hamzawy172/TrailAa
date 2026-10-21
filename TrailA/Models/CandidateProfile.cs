using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailA.Models
{
    public class CandidateProfile
    {
        public int Id { get; set; }
        [Required , Phone]
        public string Phone { get; set; }
        public string ?ResumeUrl { get; set; }
        [Required , MaxLength(500)]
        public string Skill {  get; set; }
        [Range(0, 50)]
        public int YearsOfExperince { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Application> applications { get; set; } = new List<Application>();
    }
}
