using DnD.Entities;
using DnD.Models;
using System.Collections.Generic;

namespace DnD.Repositories
{
    /*
     * Interfaccia da utilizzare per interfacciarsi con un generico sistema di salvataggio dei dati dei character.
     * Può essere un database o un file di testo, non importa, l'importante è definire il set di operazioni che si
     * possono effettuare su questa raccolta di dati, poi starà all'implementazione definirne le specifiche.
     */

    public interface ICharacterRepository
    {
        void AddItem(string owner, Item item);
        void Create(CharacterEntity entity);
        void Delete(CharacterEntity entity);
        IEnumerable<CharacterEntity> GetAll();
        IEnumerable<Item> GetAllItems();
        CharacterEntity GetByName(string characterName);
        void RemoveItem(string owner, string itemName);
        void Update(CharacterEntity entity);
        void TogglePlaying(string characterName);
    }
}
