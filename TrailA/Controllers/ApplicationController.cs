using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailA.DTOs.ApplicationDtos;
using TrailA.UnitOfWorks;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public ApplicationController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> PatchStatus(int id, PatchStatusDto dto)
        {
            var data = await u.Application.GetById(id);
            if (data==null)
            {
                return NotFound();
            }
            data.Status = dto.Status;
            u.Application.Update(data);
            await u.Save();
            return NoContent();

        }
        [Authorize(Roles = "Candidate")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await u.Application.GetAll();
            var map = mapper.Map<List<ApplicationDto>>(data);
            return Ok(map);
        }
    }
}
