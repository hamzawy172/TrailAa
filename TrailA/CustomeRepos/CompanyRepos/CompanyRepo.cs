using Microsoft.EntityFrameworkCore;
using TrailA.Data;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.CompanyRepos
{
    public class CompanyRepo : GenericRepo<Company>, IcompanyRepo
    {
        private readonly MyContext c;
        public CompanyRepo(MyContext c) : base(c)
        {
            this.c = c;
        }

        //public Task<Company> GetHighestjobs()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Company> GetHighestjobs()
        {
            var data = await c.companies.Include(a => a.jobs).OrderByDescending(a => a.jobs.Count()).FirstOrDefaultAsync();

            return data;
        }

    }
}
