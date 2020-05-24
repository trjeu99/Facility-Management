using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Group9.AbpZeroTemplate.Web.Core
{
    public class Group9WebCoreModule : AbpModule
    {
        public Group9WebCoreModule() { }

        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Group9WebCoreModule).GetAssembly());
        }
    }
}
