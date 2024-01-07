using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Interface
{
    public interface IInventoryManager
    {
        void AddItem(Item item);
        List<Item> items { get; set; }
    }
}