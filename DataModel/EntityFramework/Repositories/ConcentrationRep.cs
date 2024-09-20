using DataModel.Entities;
using DataModel.EntityFramework.Contexts;
using DataModel.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.EntityFramework.Repositories
{
    public class ConcentrationRep : IConcentration
    {
        private readonly DataContext Context;
        public ConcentrationRep(DataContext context) => Context = context;
        public IQueryable<Concentration> Items => Context.Concentrations;
        public async Task<int> DeleteAsync(Concentration item)
        {
            if(Items.Contains(item))
            {
                Context.Remove(item);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<Concentration> GetItemByIdAsync(int id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Concentration item)
        {
            var rec = await Items.FirstOrDefaultAsync(x => x.Point == item.Point);
            if (rec != default) Context.Update(item);
            else await Context.AddAsync(item);
            return await Context.SaveChangesAsync();
        }
    }
}
