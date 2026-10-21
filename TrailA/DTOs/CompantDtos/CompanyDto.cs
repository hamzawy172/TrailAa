using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrailA.Models;

namespace TrailA.DTOs.CompantDtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
        public string? Website { get; set; }
        [Required]
        public string Location { get; set; }
        public int UserId { get; set; }
    }
}
