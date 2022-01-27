using System;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<SignInResult> SignIn(SignInModel model);

        Task SignOutAsync();

        Task<IdentityResult> SignUp(SignUpModel model);
    }
}