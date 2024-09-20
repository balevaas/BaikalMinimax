using DataModel.Entities;
using DataModel.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.EntityFramework.Repositories
{
    public class PointRep
    {
        private readonly DataContext Context;
        public PointRep(DataContext dataContext) => Context = dataContext;

        public IQueryable<Point> Items => Context.Points;

        public async Task<int> DeleteAsync(Point item)
        {
            if (Items.Contains(item))
            {
                Context.Remove(item);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Point> GetItemByIdAsync(int id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Point item)
        {
            var rec = await Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if(rec != default) Context.Update(rec);
            else await Context.AddAsync(item);
            return await Context.SaveChangesAsync();
        }
    }
}
