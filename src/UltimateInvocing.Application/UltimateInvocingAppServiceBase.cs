using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.MultiTenancy;
using Abp.Net.Mail.Smtp;

namespace UltimateInvocing
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class UltimateInvocingAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }
        private readonly ISmtpEmailSender _emailSender;
        public UserManager UserManager { get; set; }

        protected UltimateInvocingAppServiceBase()
        {
            LocalizationSourceName = UltimateInvocingConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
