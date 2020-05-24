using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group11.AbpZeroTemplate.Application
{
    public class Group11ApplicationModule : AbpModule
    {
        public Group11ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group11AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group11ApplicationModule).GetAssembly());
        }
    }
}
