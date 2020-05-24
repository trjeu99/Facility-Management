﻿using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace Group6.AbpZeroTemplate.Application
{
    public class Group6AuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public Group6AuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public Group6AuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull("Pages") ?? context.CreatePermission("Pages", L("Pages"));
            var group0 = pages.CreateChildPermission("Pages.Group6", L("Group6"));


            var demoModels = pages.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car, L("Car"));
            demoModels.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car_Add, L("Create"));
            demoModels.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car_Update, L("Edit"));
            demoModels.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car_View, L("View"));
            demoModels.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car_Delete, L("Delete"));
            demoModels.CreateChildPermission(Group6PermissionsConst.Pages_Administration_Car_Approve, L("Approve"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
