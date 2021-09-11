using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsyn(SignUpUserModel signUpUserModel);
       Task<SignInResult> PasswordSignAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}