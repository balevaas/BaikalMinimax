using Microsoft.EntityFrameworkCore;

namespace DataModel.EntityFramework.Contexts
{
    public class DbContextFactory
    {
        private readonly DbContextOptions _options;
        public DbContextFactory(DbContextOptions options) => _options = options;
        public DataContext Create()
        {
            var res = new DataContext(_options);
            res.Database.EnsureCreated();
            return res;
        }
    }
}
