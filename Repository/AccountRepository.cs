using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

     
        public async Task<IdentityResult> CreateUserAsyn(SignUpUserModel signUpUserModel)
        {
            var user = new ApplicationUser()
            {
                Email=signUpUserModel.Email,
                UserName = signUpUserModel.Email,
                FirstName = signUpUserModel.FirstName,
                LastName = signUpUserModel.LastName
           
            };
            var result =await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignAsync(SignInModel signInModel)
        {
            var res = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return res;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
