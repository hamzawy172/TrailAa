using AutoMapper;
using TrailA.DTOs.CandidateProfileDtos;
using TrailA.Models;

namespace TrailA.Mappings
{
    public class CandidateProfileProfile : Profile
    {
        public CandidateProfileProfile()
        {
            CreateMap<UpdateCandidateProfile, CandidateProfile>();
        }
    }
}
