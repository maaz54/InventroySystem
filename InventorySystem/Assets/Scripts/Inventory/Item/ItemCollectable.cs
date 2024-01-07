using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Represents a collectable item in the game world.
    /// </summary>
    public class ItemCollectable : MonoBehaviour
    {
        // The item associated with the collectable.
        [SerializeField] internal Item item;

        // triggered when the item is collected.
        public Action<Item> OnItemCollect;


        /// <summary>
        /// Collects the item, invoking the OnItemCollect event.
        /// </summary>
        internal void CollectItem()
        {
            OnItemCollect?.Invoke(item);
        }
    }
}