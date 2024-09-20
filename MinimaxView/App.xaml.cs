using System.Windows;
using DataModel.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using static ConnectionConfig.Strings;

namespace MinimaxView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DbContextFactory _context;

        public DataContext Context => _context.Create();

        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlite(GetConnectionStrings(Sqlite));

            this._context = new DbContextFactory(builder.Options);
        }
    }
}
