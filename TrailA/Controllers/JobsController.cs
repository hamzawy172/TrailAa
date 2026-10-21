using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.CompilerServices;
using TrailA.DTOs.JobDtos;
using TrailA.UnitOfWorks;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public JobsController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [HttpGet("Third-highest-salasry")]
        public async Task<IActionResult> Geythirdhighh()
        {
            var data = await u.Job.thirdHighestSalary();
            if (data == 0)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await u.Job.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            var map = mapper.Map<JobDto>(data);
            return Ok(map);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await u.Job.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            u.Job.Delete(id);
            await u.Save();

            return NoContent();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var data = await u.Job.Search(keyword);
            if (data == null)
            {
                return BadRequest();
            }
            var map = mapper.Map<List<JobDto>>(data);
            return Ok(map);
        }
    }
}
