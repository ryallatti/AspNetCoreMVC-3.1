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
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

     
        public async Task<IdentityResult> CreateUserAsyn(SignUpUserModel signUpUserModel)
        {
            var user = new IdentityUser()
            {
                Email=signUpUserModel.Email,
                UserName = signUpUserModel.Email

            };
            var result =await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }
     
    }
}
