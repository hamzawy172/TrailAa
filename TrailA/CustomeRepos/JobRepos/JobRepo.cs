using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.JobRepos
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        private readonly MyContext c;
        public JobRepo(MyContext c) : base(c)
        {
            this.c = c;
        }

        public async Task<List<Job>> Search(string Keyword)
        {
            var data = await c.jobs.Where(a => a.Title.Contains(Keyword) || a.Description.Contains(Keyword)).ToListAsync();
            return data;
        }

        public async Task<decimal> thirdHighestSalary()
        {
            var data = await c.jobs.OrderByDescending(a => a.Salary).Distinct().Skip(2).Select(a => a.Salary).FirstOrDefaultAsync();
            return data;
        }
    }

}
