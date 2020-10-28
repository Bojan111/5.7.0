using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using TestDBTest.EntityFramework;

namespace TestDBTest.Migrator
{
    [DependsOn(typeof(TestDBTestDataModule))]
    public class TestDBTestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TestDBTestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}