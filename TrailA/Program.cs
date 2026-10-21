
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrailA.CustomeRepos.AuthRepos;
using TrailA.CustomeRepos.CompanyRepos;
using TrailA.CustomeRepos.JobRepos;
using TrailA.Data;
using TrailA.GenericRepos;
using TrailA.UnitOfWorks;

namespace TrailA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuthRepo, AuthRepo>();
            builder.Services.AddScoped<IJobRepo, JobRepo>();
            builder.Services.AddScoped<IcompanyRepo, CompanyRepo>();
            builder.Services.AddAutoMapper(typeof(Program));

            // Add services to the container.




            // commit update get


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:key"]));
            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(op => op.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ValidIssuer = builder.Configuration["JWT:issuer"],
                ValidAudience = builder.Configuration["JWT:audience"],

            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
