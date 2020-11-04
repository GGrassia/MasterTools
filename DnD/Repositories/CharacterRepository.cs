using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DnD.Entities;

namespace DnD.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext context;

        public CharacterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Character CRUD
        public Task<int> Create(Character entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<Character> GetAll()
            => context.Set<Character>();

        public Task<Character> Get(int id)
            => await GetAll().FirstAsync(c => c.Id == id);

        public Task Update(Character entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task Delete(Character entity)
        {
            context.Remove();
            await context.SaveChangesAsync();
        }

        Task<Character> GetByName(string characterName)
            => await GetAll().FirstAsync(c => c.CharacterName == characterName);

        Task TogglePlaying(string characterName)
        {
            var character = await GetByName(characterName);
            character.Playing = !character.Playing;
            await Update(character);
        }

        Task<IEnumerable<Character>> GetActiveCharacters()
            => await GetAll().Where(c => c.Playing).ToListAsync();
    }
}