using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Inventory
    {
        public List<Item> items { get; set; }

        public Inventory()
        {
            items = new List<Item>();
        }
    }

}