using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group2.AbpZeroTemplate.Application
{
    public class Group2ApplicationModule : AbpModule
    {
        public Group2ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group2AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group2ApplicationModule).GetAssembly());
        }
    }
}
