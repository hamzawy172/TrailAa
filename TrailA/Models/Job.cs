using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailA.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required , Range(0,1000000)]
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required , RegularExpression("^(Open|Colsed)$")]
        public string Status { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Application> applications { get; set; } = new List<Application>();

    }
}
