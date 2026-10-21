using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.JobRepos
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<decimal> thirdHighestSalary();
        Task<List<Job>>Search(string Keyword);
    }
}
