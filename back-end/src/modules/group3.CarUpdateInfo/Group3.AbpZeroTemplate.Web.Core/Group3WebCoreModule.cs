using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group3.AbpZeroTemplate.Web.Core
{
    public class Group3WebCoreModule : AbpModule
    {
        public Group3WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group3WebCoreModule).GetAssembly());
        }
    }
}
