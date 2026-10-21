using TrailA.DTOs.AuthDtos;
using TrailA.GenericRepos;
using TrailA.Models;

namespace TrailA.CustomeRepos.AuthRepos
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<string> Login(LoginDto dto);
        Task<bool> Register(User user);
        Task<bool> eamilexi(string email);
        
    }
}
