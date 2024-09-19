using DataModel.Entities;
using DataModel.EntityFramework.Contexts;
using DataModel.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataModel.EntityFramework.Repositories
{
    internal class CityRep : ICity
    {
        private readonly DataContext Context;
        public CityRep(DataContext dataContext) => Context = dataContext;

        public IQueryable<City> Items => Context.Cities;

        public async Task<int> DeleteAsync(City item)
        {
            if (Items.Contains(item))
            {
                Context.Remove(item);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<City> GetItemByIdAsync(int id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(City item)
        {
            var rec = await Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (rec != default) Context.Update(item);
            else await Context.AddAsync(item);
            return await Context.SaveChangesAsync();
        }
    }
}
