using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailA.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required , RegularExpression("^(Pending|UnderReview|Accepted|Rejectd)$")]
        public string Status { get; set; }
        public string ?CoverLetter { get; set; }

        [ForeignKey(nameof(candidateProfile))]
        public int CandidateProfileId { get; set; }
        public CandidateProfile candidateProfile { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
