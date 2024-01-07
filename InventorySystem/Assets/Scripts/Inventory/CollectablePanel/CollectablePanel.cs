using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InventorySystem.Interface;

namespace InventorySystem
{
    /// <summary>
    /// Represents a collectable panel that displays item collectables.
    /// </summary>
    public class CollectablePanel : MonoBehaviour, ICollectablePanel
    {
        /// <summary>
        /// Reference to the RectTransform that holds the collectable slots.
        /// </summary>
        [SerializeField] RectTransform slotHolder;

        /// <summary>
        /// Array of item collectables displayed in the panel
        /// </summary>
        [SerializeField] ItemCollectable[] itemCollectables;

        /// <summary>
        /// triggered when an item is collected
        /// </summary>
        public Action<Item> OnItemCollect { get; set; }

        private void Start()
        {
            itemCollectables.ToList().ForEach(i => i.OnItemCollect += ItemCollected);
        }

        /// <summary>
        /// Invokes the OnItemCollect event with the collected item.
        /// </summary>
        private void ItemCollected(Item item)
        {
            OnItemCollect?.Invoke(item);
        }

    }
}
