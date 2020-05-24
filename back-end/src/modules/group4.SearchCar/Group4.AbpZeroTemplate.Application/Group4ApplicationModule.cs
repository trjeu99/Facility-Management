using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group4.AbpZeroTemplate.Application
{
    public class Group4ApplicationModule : AbpModule
    {
        public Group4ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group4AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group4ApplicationModule).GetAssembly());
        }
    }
}
