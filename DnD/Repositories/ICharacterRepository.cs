using DnD.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace DnD.Repositories
{
    // Questa è l'interfaccia generica per la repository dei character
    public interface ICharacterRepository
    {
        // Characters CRUD (Create Read Update Delete)
        Task<int> Create(Character entity);
        IQueryable<Character> GetAll();
        Task<Character> Get(int id);
        Task Delete(Character entity);
        Task Update(Character entity);
    }
}
