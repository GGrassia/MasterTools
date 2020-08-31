namespace DnD.Models
{
    public class Item
    {
        /// <summary>If the item is a weapon, piece of armour, a kit or stuff you've found</summary>
        public string Type { get; set; }

        /// <summary>How many of this item you have in the inventory, specially useful for potions</summary>
        public int Number { get; set; }

        /// <summary>Is the item in question magic or not</summary>
        public bool IsMagic { get; set; }

        /// <summary>The name of the item</summary>
        public string Name { get; set; }

        /// <summary>An indicative sum you would make from selling the item, or the countervalue for a component (IE the diamond dust for stoneskin)</summary>
        public int Value { get; set; }

        /// <summary>Description of the item, it's function or properties, if necessary</summary>
        public string Description { get; set; }

        /// <summary>Name of the character currently keeping or owning the item</summary>
        public string Owner { get; set; }
    }
}
