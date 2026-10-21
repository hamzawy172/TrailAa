using Microsoft.EntityFrameworkCore;
using TrailA.Models;

namespace TrailA.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<CandidateProfile> candidateProfiles { get; set; }
        public DbSet<Application> applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.CandidateProfile)
                .WithOne(a => a.User)
                .HasForeignKey<CandidateProfile>(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasMany(a => a.companies)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Company>()
                .HasMany(a => a.jobs)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId);

            modelBuilder.Entity<CandidateProfile>()
                .HasMany(a => a.applications)
                .WithOne(a => a.candidateProfile)
                .HasForeignKey(a => a.CandidateProfileId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Job>()
                .HasMany(a => a.applications)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Application>()
                .HasIndex(a => new { a.JobId, a.CandidateProfileId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique();




            modelBuilder.Entity<User>()
                .HasData(

                new User
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Password = "123456",
                    Role = "Candidate",
                    CreatedAt = new DateTime(2026, 9, 1),
                },
                new User
                {
                    Id = 2,
                    FullName = "Sara Mohammed",
                    Email = "sara@example.com",
                    Password = "123456",
                    Role = "Employer",
                    CreatedAt = new DateTime(2026, 9, 2),
                },
                new User
                {
                    Id = 3,
                    FullName = "Omar Ali",
                    Email = "omar@example.com",
                    Password = "123456",
                    Role = "Admin",
                    CreatedAt = new DateTime(2026, 9, 3),
                },
                new User
                {
                    Id = 4,
                    FullName = "Hamza Ahmed",
                    Email = "hamza@example.com",
                    Password = "123456",
                    Role = "Candidate",
                    CreatedAt = new DateTime(2026, 9, 4),
                }
                );

            modelBuilder.Entity<CandidateProfile>()
                .HasData(
                new CandidateProfile
                {
                    Id = 1,
                    Phone = "012345678",
                    ResumeUrl = "example.com/resume1",
                    Skill = "ASP.NET core",
                    YearsOfExperince = 3,
                    UserId = 1
                },
                new CandidateProfile
                {
                    Id = 2,
                    Phone = "01098765432",
                    ResumeUrl = "example.com/resume2",
                    Skill = "Java",
                    YearsOfExperince = 2,
                    UserId = 4
                }

                );

            modelBuilder.Entity<Company>()
                .HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech Solutions",
                    Description = "Software Develpoment Company",
                    Website = "https://TechSolutions.example.com",
                    Location = "Cairo",
                    UserId = 2
                },
                new Company
                {
                    Id = 2,
                    Name = "Future Systems",
                    Description = "IT Cons Company",
                    Website = "https://FutureSystems.example.com",
                    Location = "Giza",
                    UserId = 2
                }
                );
            modelBuilder.Entity<Job>()
                .HasData(
                new Job
                {
                    Id = 1,
                    Title = "Backend Developer",
                    Description = "Developing apis using .nwt core",
                    Location = "Cairo",
                    EmploymentType = "FullTime",
                    PostedDate = new DateTime(2026, 10, 1),
                    DeadLine = new DateTime(2026, 11, 1),
                    Status = "Open",
                    Salary = 30000,
                    CompanyId = 1
                },
                new Job
                {
                    Id = 2,
                    Title = "Frontend Developer",
                    Description = "Developing Web interfaces",
                    Location = "Giza",
                    EmploymentType = "FullTime",
                    PostedDate = new DateTime(2026, 10, 2),
                    DeadLine = new DateTime(2026, 11, 2),
                    Status = "Open",
                    Salary = 25000,
                    CompanyId = 2
                }
                );
            modelBuilder.Entity<Application>()
                .HasData(
                new Application
                {
                    Id = 1,
                    ApplicationDate = new DateTime(2026, 10, 5),
                    Status = "Pending",
                    CoverLetter = "interested in backend development",
                    CandidateProfileId = 1,
                    JobId = 1,
                },
                new Application
                {
                    Id = 2,
                    ApplicationDate = new DateTime(2026, 10, 6),
                    Status = "UnderReview",
                    CoverLetter = "interested in web technolgy",
                    CandidateProfileId = 2,
                    JobId = 2,
                }
                );
        }

    }
}
