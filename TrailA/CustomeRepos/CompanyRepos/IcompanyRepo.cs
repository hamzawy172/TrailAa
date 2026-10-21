using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.CompanyRepos
{
    public interface IcompanyRepo : IGenericRepo<Company>
    {
        Task<Company> GetHighestjobs();
    }
}
