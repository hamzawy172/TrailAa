using TrailA.CustomeRepos.AuthRepos;
using TrailA.CustomeRepos.CompanyRepos;
using TrailA.CustomeRepos.JobRepos;
using TrailA.Data;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepo<Application> Application { get; }

        public IGenericRepo<CandidateProfile> CandidateProfile {  get; }

        public IcompanyRepo Company {  get; }

        public IJobRepo Job {  get; }

        public IGenericRepo<User> User {  get; }
        public IAuthRepo Auth {  get; }



        private readonly MyContext c;

        public UnitOfWork(IAuthRepo Auth,IGenericRepo<Application> Application , IGenericRepo<CandidateProfile> CandidateProfile , IcompanyRepo Company , IJobRepo Job , IGenericRepo<User> User, MyContext c)
        {
            this.Application = Application;
            this.CandidateProfile = CandidateProfile;
            this.Company = Company;
            this.Job = Job;
            this.User = User;
            this.c = c;
            this.Auth = Auth;
        }


        public async Task Save()
        {
            await c.SaveChangesAsync();
        }
    }
}
