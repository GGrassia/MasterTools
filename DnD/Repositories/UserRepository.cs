using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DnD.Entities;
using System.Linq;

namespace DnD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(User entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public IQueryable<User> GetAll()
            => context.Set<User>();

        public async Task<User> Get(int id)
            => await GetAll().FirstAsync(c => c.Id == id);

        public async Task Update(User entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}