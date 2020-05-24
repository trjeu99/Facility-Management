using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group9.AbpZeroTemplate.Application
{
    public class Group9ApplicationModule : AbpModule
    {
        public Group9ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group9AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group9ApplicationModule).GetAssembly());
        }
    }
}
