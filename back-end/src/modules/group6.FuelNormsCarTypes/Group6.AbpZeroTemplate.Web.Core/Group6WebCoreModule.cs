using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group6.AbpZeroTemplate.Web.Core
{
    public class Group6WebCoreModule : AbpModule
    {
        public Group6WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group6WebCoreModule).GetAssembly());
        }
    }
}
