using System.Security.AccessControl;
using DnD.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnD.Repositories
{
    /*
     * Interfaccia da utilizzare per interfacciarsi con un generico sistema di salvataggio dei dati dei character.
     * Può essere un database o un file di testo, non importa, l'importante è definire il set di operazioni che si
     * possono effettuare su questa raccolta di dati, poi starà all'implementazione definirne le specifiche.
     */

    public interface ICharacterRepository
    {
        // Character CRUD
        Task<int> Create(Character entity);
        IQueryable<Character> GetAll();
        Task<Character> Get(int id);
        Task Delete(Character entity);
        Task Update(Character entity);
        
        Character GetByName(string characterName);
        void TogglePlaying(string characterName);
        IEnumerable<Character> GetActiveCharacters();
    }
}
