using EcommerceCaseStudy.DTO.Auth;

namespace EcommerceCaseStudy.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(RegisterDTO dto);
    }
}
