using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group1.AbpZeroTemplate.Application
{
    public class Group1ApplicationModule : AbpModule
    {
        public Group1ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group1AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group1ApplicationModule).GetAssembly());
        }
    }
}
