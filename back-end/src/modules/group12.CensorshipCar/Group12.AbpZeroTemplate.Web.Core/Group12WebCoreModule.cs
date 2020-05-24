using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group12.AbpZeroTemplate.Web.Core
{
    public class Group12WebCoreModule : AbpModule
    {
        public Group12WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group12WebCoreModule).GetAssembly());
        }
    }
}
