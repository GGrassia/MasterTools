using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace DnD.Models
{
    public class Character
    {
        //Name of the Character
        [BsonId]
        public Guid Id { get; set; }
        public string CharacterName {get; set;}
        //Class of the character
        public string Class { get; set; }
        //Level of the character
        public int Level { get; set; }
        //Name player controlling the character
        public string PlayerName { get; set; }
        //What the character has with him/her
        public List<Item> Inventory { get; set; }
        //The  old the character has with him/her
        public int Gold { get; set; }
        //Init ative bonus of the character, in case they trust you to roll their initiative
        public int InitiativeBonus { get; set; }
        //Pass ve perception of the character
        public int PassivePerception { get; set; }
        //Pass ve insight of the character
        public int PassiveInsight { get; set; }
        //Heal h points of the character, helpful if you want to cast sleep or other spells
        public int Hp { get; set; }
    }
}
