using AutoMapper;
using TrailA.DTOs.JobDtos;
using TrailA.Models;

namespace TrailA.Mappings
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>();
            CreateMap<Job, JobSalaryDto>();

        }
    }
}
