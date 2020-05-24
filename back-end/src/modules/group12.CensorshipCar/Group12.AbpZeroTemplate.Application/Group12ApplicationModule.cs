using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group12.AbpZeroTemplate.Application
{
    public class Group12ApplicationModule : AbpModule
    {
        public Group12ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group12AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group12ApplicationModule).GetAssembly());
        }
    }
}
