﻿using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Abp.Threading;
using GSoft.AbpZeroTemplate;
using GSoft.AbpZeroTemplate.Authorization.Users;
using GSoft.AbpZeroTemplate.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Group1.AbpZeroTemplate.Application
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Group1AppServiceBase : ApplicationService
    {

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}