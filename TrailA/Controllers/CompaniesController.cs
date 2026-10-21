using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TrailA.DTOs.CompantDtos;
using TrailA.UnitOfWorks;

namespace TrailA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public CompaniesController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [HttpGet("most-jobs")]
        public async Task<IActionResult> MostJobs()
        {
            var data = await u.Company.GetHighestjobs();
            var map = mapper.Map<CompanyDto>(data);
            return Ok(map);
        }
    }
}
