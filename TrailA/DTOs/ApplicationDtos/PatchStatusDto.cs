using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs.ApplicationDtos
{
    public class PatchStatusDto
    {
        [Required, RegularExpression("^(Pending|UnderReview|Accepted|Rejectd)$")]
        public string Status { get; set; }
    }
}
