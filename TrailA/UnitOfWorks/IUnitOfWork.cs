using TrailA.CustomeRepos.AuthRepos;
using TrailA.CustomeRepos.CompanyRepos;
using TrailA.CustomeRepos.JobRepos;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAuthRepo Auth {  get; }
        IGenericRepo<Application> Application {  get; }
        IGenericRepo<CandidateProfile> CandidateProfile { get; }
        IcompanyRepo Company { get; }
        IJobRepo Job { get; }
        IGenericRepo<User> User { get; }

        Task Save();
    }
}
