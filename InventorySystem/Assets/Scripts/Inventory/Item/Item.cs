using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Serializable class representing an item.
    /// </summary>
    [System.Serializable]
    public class Item
    {
        /// <summary>
        /// The quantity of the item.
        /// </summary>
        [field: SerializeField] public int Quantity { get; set; }
        
        /// <summary>
        /// The data associated with the item
        /// </summary>
        [field: SerializeField] public ItemData ItemData { get; set; }

        public Item(ItemData itemData, int Quantity)
        {
            this.ItemData = itemData;
            this.Quantity = Quantity;
        }
    }

}