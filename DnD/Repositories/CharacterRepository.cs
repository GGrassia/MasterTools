using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DnD.Entities;
using System.Linq;
using System.Collections.Generic;

namespace DnD.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext context;

        public CharacterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(Character entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<Character> GetAll()
            => context.Set<Character>();

        public async Task<Character> Get(int id)
            => await GetAll().FirstAsync(c => c.Id == id);

        public async Task Update(Character entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Character entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}