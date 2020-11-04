using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DnD.Entities;

namespace DnD.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Character CRUD
        public Task<int> Create(Item entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<Item> GetAll()
            => context.Set<Item>();

        public Task<Item> Get(int id)
            => await GetAll().FirstAsync(c => c.Id == id);

        public Task Update(Item entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task Delete(Item entity)
        {
            context.Remove();
            await context.SaveChangesAsync();
        }
    }    
}