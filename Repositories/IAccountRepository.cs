using bookstore.api.Models;
using Microsoft.AspNetCore.Identity;

namespace bookstore.api.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpDto model);
        public Task<string> SignInAsync(SignInDto model);
    }
}
