using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DnD.Entities;
using System.Linq;

namespace DnD.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(Item entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<Item> GetAll()
            => context.Set<Item>();

        public async Task<Item> Get(int id)
            => await GetAll().FirstAsync(c => c.Id == id);

        public async Task Update(Item entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Item entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }    
}