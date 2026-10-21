using AutoMapper;
using TrailA.DTOs.ApplicationDtos;
using TrailA.Models;

namespace TrailA.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDto>();
        }
    }
}
