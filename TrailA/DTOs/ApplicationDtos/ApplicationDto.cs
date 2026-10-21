using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrailA.Models;

namespace TrailA.DTOs.ApplicationDtos
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required, RegularExpression("^(Pending|UnderReview|Accepted|Rejectd)$")]
        public string Status { get; set; }
        public string? CoverLetter { get; set; }

        public int CandidateProfileId { get; set; }

        public int JobId { get; set; }
    }
}
