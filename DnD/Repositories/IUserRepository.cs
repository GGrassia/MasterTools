using DnD.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Repositories
{
    public interface IUserRepository
    {
        // Users CRUD
        Task<int> Create(User entity);
        IQueryable<User> GetAll();
        Task<User> Get(int id);
        Task Delete(User entity);
        Task Update(User entity);
    }
}
