using System.ComponentModel.DataAnnotations;

namespace TrailA.DTOs.JobDtos
{
    public class JobSalaryDto
    {
        [Required, Range(0, 1000000)]
        public decimal Salary { get; set; }
    }
}
