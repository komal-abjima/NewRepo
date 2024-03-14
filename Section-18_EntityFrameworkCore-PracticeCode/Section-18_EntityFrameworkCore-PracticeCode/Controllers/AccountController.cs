using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section_18_EntityFrameworkCore_PracticeCode.Models;
using Section_18_EntityFrameworkCore_PracticeCode.Repository;

namespace Section_18_EntityFrameworkCore_PracticeCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpModel signupmodel)
        {
            var result = await _accountRepository.SignUpAsync(signupmodel);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();

            }
            return Ok(result);
        }
    }
}
