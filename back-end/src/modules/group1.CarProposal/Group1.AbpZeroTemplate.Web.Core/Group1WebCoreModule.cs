using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group0.AbpZeroTemplate.Web.Core
{
    public class Group0WebCoreModule : AbpModule
    {
        public Group0WebCoreModule() { }

        public override void Initialize()
        {
            
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group0WebCoreModule).GetAssembly());
        }
    }
}
