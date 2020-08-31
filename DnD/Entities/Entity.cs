using LiteDB;
using System;

namespace DnD.Entities
{
    /*
     * Classe astratta che identifica un'entità del database con un Id
     * Qualunque altra classe che vuoi salvare a database erediterà da questa master class
     * E' astratta perchè non deve poter essere istanziata così com'è, solo classi che derivano da questa
     * (non avrebbe senso istanziare una classe vuota con solo un Id)
     */

    public abstract class Entity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
