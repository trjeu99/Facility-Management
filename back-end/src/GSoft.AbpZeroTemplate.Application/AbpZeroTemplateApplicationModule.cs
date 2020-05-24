using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Group0.AbpZeroTemplate.Application;
using GSoft.AbpZeroTemplate.Authorization;
using GWebsite.AbpZeroTemplate.Application;
using Group1.AbpZeroTemplate.Application;

namespace GSoft.AbpZeroTemplate
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(AbpZeroTemplateCoreModule),
        typeof(GWebsiteApplicationModule),
        typeof(Group0ApplicationModule),
        typeof(Group1ApplicationModule)
        )]
    public class AbpZeroTemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateApplicationModule).GetAssembly());
        }
    }
}