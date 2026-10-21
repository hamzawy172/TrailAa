using AutoMapper;
using TrailA.DTOs.CompantDtos;
using TrailA.Models;

namespace TrailA.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
