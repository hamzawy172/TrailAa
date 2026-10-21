using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.DTOs.CandidateProfileDtos;
using TrailA.UnitOfWorks;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfilesController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public CandidateProfilesController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCandidateProfile dto)
        {
            var data = await u.CandidateProfile.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            mapper.Map(dto , data);
            u.CandidateProfile.Update(data);
            await u.Save();

            return NoContent();
        }
    }
}
