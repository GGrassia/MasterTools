using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD.Models
{
    public class Item
    {
        //If the item is a weapon, piece of armour, a kit or stuff you've found
        public string Type { get; set; }
        //How many of this item you have in the inventory, specially useful for potions
        public int Number { get; set; }
        //Is the item in question magic or not
        public bool Magic { get; set; }
        //The name of the item
        public string Name { get; set; }
        //An indicative sum you would make from selling the item, or the countervalue for a component (IE the diamond dust for stoneskin)
        public int Value { get; set; }
        //Description of the item, it's function or properties, if necessary
        public string Description { get; set; }
        //Name of the character currently keeping or owning the item
        public string Owner { get; set; }

    }
}
