using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group2.AbpZeroTemplate.Web.Core
{
    public class Group2WebCoreModule : AbpModule
    {
        public Group2WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group2WebCoreModule).GetAssembly());
        }
    }
}
