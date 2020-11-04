using DnD.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnD.Repositories
{
    public interface IItemRepository
    {
        // Character CRUD
        Task<int> Create(Item entity);
        IQueryable<Item> GetAll();
        Task<Item> Get(int id);
        Task Delete(Item entity);
        Task Update(Item entity);
    }
}
