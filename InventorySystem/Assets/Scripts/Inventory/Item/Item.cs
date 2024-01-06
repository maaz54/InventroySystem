using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Item
    {
        [field: SerializeField] public int Quantity { get; set; }
        [field: SerializeField] public ItemData ItemData { get; set; }

        public Item(ItemData itemData, int Quantity)
        {
            this.ItemData = itemData;
            this.Quantity = Quantity;
        }
    }

}