using TestDBTest.EntityFramework;
using EntityFramework.DynamicFilters;

namespace TestDBTest.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TestDBTestDbContext _context;

        public InitialHostDbBuilder(TestDBTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
