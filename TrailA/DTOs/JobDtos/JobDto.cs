using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrailA.Models;

namespace TrailA.DTOs.JobDtos
{
    public class JobDto
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required, Range(0, 1000000)]
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required, RegularExpression("^(Open|Colsed)$")]
        public string Status { get; set; }

        public int CompanyId { get; set; }
    }
}
