using System.Reflection.PortableExecutable;
using DnD.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD.Repositories
{
    /*
     * Questa è un'implementazione dell'interfaccia generica ICharacterRepository, in questo specifico caso viene
     * implementata come collection in un database di tipo LiteDB, ma avremmo potuto implementarla anche con altri tipi
     * di database o file testuali o addirittura dati binari raw.
     */

    public class LiteDbCharacterRepository : ICharacterRepository, IDisposable
    {
        private LiteDatabase db;
        private ILiteCollection<CharacterEntity> characters;

        /// <summary>
        /// Creates a LiteDB character repository given a path to a database file.
        /// </summary>
        /// <param name="dbPath">The path to the database file</param>
        public LiteDbCharacterRepository(string dbPath)
        {
            db = new LiteDatabase(dbPath);
            characters = db.GetCollection<CharacterEntity>();
        }

        // Dobbiamo implementare IDisposable visto che non stiamo usando using(), altrimenti non verrebbero deallocate
        // le risorse del database quando ci sbarazziamo di questa classe! E' importante!
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<CharacterEntity> GetAll()
            => characters.FindAll();

        public void Update(CharacterEntity entity)
            => characters.Update(entity);

        public void Create(CharacterEntity entity)
            => characters.Insert(entity);

        public void Delete(CharacterEntity entity)
            => characters.DeleteMany(c => c.Id == entity.Id);

        public CharacterEntity GetByName(string characterName)
            => characters.FindOne(c => c.CharacterName == characterName);

        public void AddItem(string owner, Item item)
        {
            var character = GetByName(owner) ?? throw new KeyNotFoundException();
            character.Inventory.Add(item);
            Update(character);
        }

        public void RemoveItem(string owner, string itemName)
        {
            var character = GetByName(owner) ?? throw new KeyNotFoundException();
            var itemToRemove = character.Inventory.First(i => i.Name == itemName);
            character.Inventory.Remove(itemToRemove);
            Update(character);
        }

        public void TogglePlaying(string characterName)
        {
            var character = GetByName(characterName) ?? throw new KeyNotFoundException();
            character.Playing = !character.Playing;
            Update(character);
        }

        public IEnumerable<Item> GetAllItems()
            => GetAll().SelectMany(c => c.Inventory);
        public IEnumerable<CharacterEntity> GetActiveCharacters()
            => GetAll().Where(c => c.Playing);
    }
}
