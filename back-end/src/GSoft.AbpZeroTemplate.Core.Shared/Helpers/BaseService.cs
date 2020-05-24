using Abp.Dependency;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSoft.AbpZeroTemplate.Helpers
{
    public class BaseService
    {
        protected IProcedureHelper procedureHelper;
        private IHttpContextAccessor httpContextAccessor;

        public BaseService()
        {
            httpContextAccessor = IocManager.Instance.Resolve<IHttpContextAccessor>();
            procedureHelper = IocManager.Instance.IocContainer.Resolve<IProcedureHelper>();
        }

        public string GetClaimValue(string claimKey)
        {
            var claims = httpContextAccessor.HttpContext?.User.Identities.First().Claims;
            return claims.FirstOrDefault(x => x.Type == claimKey)?.Value;
        }

        public string GetCurrentUserName()
        {
            return GetClaimValue("UserName");
        }
    }
}
