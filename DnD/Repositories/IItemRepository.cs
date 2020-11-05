using DnD.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Repositories
{
    // Questa è l'interfaccia generica per la repository degli item
    public interface IItemRepository
    {
        // Items CRUD
        Task<int> Create(Item entity);
        IQueryable<Item> GetAll();
        Task<Item> Get(int id);
        Task Delete(Item entity);
        Task Update(Item entity);
    }
}
