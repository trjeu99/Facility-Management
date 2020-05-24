using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group11.AbpZeroTemplate.Web.Core
{
    public class Group11WebCoreModule : AbpModule
    {
        public Group11WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group11WebCoreModule).GetAssembly());
        }
    }
}
