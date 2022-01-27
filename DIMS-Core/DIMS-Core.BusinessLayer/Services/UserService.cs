using System;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models.Account;
using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Services
{
    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IIdentityUnitOfWork _unitOfWork;

        public UserService(IIdentityUnitOfWork identityUnitOfWork, IMapper mapper)
        {
            _unitOfWork = identityUnitOfWork;
            _mapper = mapper;
        }

        public async Task<SignInResult> SignIn(SignInModel model)
        {
            Guard.Argument(model)
                 .NotNull();
            
            var result = await _unitOfWork.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task<IdentityResult> SignUp(SignUpModel model)
        {
            Guard.Argument(model)
                 .NotNull();

            var mappedEntity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserManager.CreateAsync(mappedEntity, model.Password);

            return result;
        }

        public Task SignOutAsync()
        {
            return _unitOfWork.SignInManager.SignOutAsync();
        }
    }
}