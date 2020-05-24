using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group3.AbpZeroTemplate.Application
{
    public class Group3ApplicationModule : AbpModule
    {
        public Group3ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group3AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group3ApplicationModule).GetAssembly());
        }
    }
}
