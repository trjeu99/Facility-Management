using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group0.AbpZeroTemplate.Application
{
    public class Group0ApplicationModule : AbpModule
    {
        public Group0ApplicationModule() { }

        public override void Initialize()
        {
            Configuration.Authorization.Providers.Add<Group0AuthorizationProvider>();
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group0ApplicationModule).GetAssembly());
        }
    }
}
