using bookstore.api.Models;
using bookstore.api.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace bookstore.api.Controllers
{
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            _accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto obj)
        {
            var result=await _accountRepo.SignUpAsync(obj);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto obj)
        {
            var token=await _accountRepo.SignInAsync(obj);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
