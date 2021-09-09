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

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
     
    }
}
