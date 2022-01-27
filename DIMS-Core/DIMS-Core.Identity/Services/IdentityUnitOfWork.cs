using System;
using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.Identity.Services
{
    internal class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SignInManager { get; }

        #region Disposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                UserManager.Dispose();
            }

            _disposed = true;
        }

        ~IdentityUnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}