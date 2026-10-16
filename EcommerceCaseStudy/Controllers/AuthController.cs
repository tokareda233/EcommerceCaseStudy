using EcommerceCaseStudy.DTO.Auth;
using EcommerceCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public AuthController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var token =await _unit.AuthRepo.Login(dto);
            if (token == null) { return Unauthorized("email or password invalid"); }

            return Ok(token);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var u =await _unit.AuthRepo.Register(dto);

            if (u) { return Created(); }
 
            return BadRequest("email already exeist");

        }
    }
}
