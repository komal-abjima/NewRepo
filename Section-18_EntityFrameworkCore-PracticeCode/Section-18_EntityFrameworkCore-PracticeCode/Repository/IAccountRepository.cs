using Microsoft.AspNetCore.Identity;
using Section_18_EntityFrameworkCore_PracticeCode.Models;

namespace Section_18_EntityFrameworkCore_PracticeCode.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signinmodel);
    }
}
