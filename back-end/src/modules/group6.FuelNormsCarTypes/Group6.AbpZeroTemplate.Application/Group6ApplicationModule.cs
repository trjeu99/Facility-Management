using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group6.AbpZeroTemplate.Application
{
    public class Group6ApplicationModule : AbpModule
    {
        public Group6ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group6AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group6ApplicationModule).GetAssembly());
        }
    }
}
