using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Item
    {
        [field: SerializeField] public int Quantity { get; set; }
        [SerializeField] ItemData itemData;
        public ItemData ItemData => itemData;

        public Item(ItemData itemData, int Quantity)
        {
            this.itemData = itemData;
            this.Quantity = Quantity;
        }
    }

}