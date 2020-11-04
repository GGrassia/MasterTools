using DnD.Entities;
using DnD.Models;
using System.Collections.Generic;

namespace DnD.Entities
{
    public class CharacterEntity : Entity
    {
        /// <summary>Name of the Character</summary>
        public string CharacterName {get; set;}

        /// <summary>Class of the Character</summary>
        public string Class { get; set; }

        /// <summary>Level of the Character</summary>
        public int Level { get; set; }

        /// <summary>Name of the Player</summary>
        public string PlayerName { get; set; }

        /// <summary>What the character is carrying</summary>
        public List<Item> Inventory { get; set; }

        /// <summary>The amount of Gold the character is carrying</summary>
        public int Gold { get; set; }

        /// <summary>Initiative bonus of the character, in case they trust you to roll their initiative</summary>
        public int InitiativeBonus { get; set; }

        /// <summary>Passive perception of the character</summary>
        public int PassivePerception { get; set; }

        /// <summary>Passive insight of the character</summary>
        public int PassiveInsight { get; set; }

        /// <summary>Health points of the character, helpful if you want to cast sleep or other spells</summary>
        public int Hp { get; set; }

        /// <summary>Toggle if the character is playing or not</summary>
        public bool Playing {get; set;}
    }
}
