using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.User;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authrepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authrepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authrepo.Register(new User{ Username = request.Username }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);

            }
            return Ok(response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authrepo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);

            }
            return Ok(response);

        }
    }
}
