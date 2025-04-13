using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using TRAODOITAILIEU.BusinessLayer.DTOs;
using TRAODOITAILIEU.BusinessLayer.Interfaces;

namespace TRAODOITAILIEU.PresentationLayer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                var userDto = accountService.Register(request);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            UserDTO user = accountService.Login(request);
            return Ok(user);
        }
    }
}
