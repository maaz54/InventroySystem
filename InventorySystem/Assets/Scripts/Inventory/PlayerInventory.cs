using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using InventorySystem.Interface;

namespace InventorySystem
{
    /// <summary>
    /// Manages the player's inventory and interaction with collectable items in the game.
    /// </summary>
    public class PlayerInventory : MonoBehaviour
    {
        IInventoryManager inventoryManager;
        ICollectablePanel collectablePanel;

        // Constructor using dependency injection to initialize inventoryManager and collectablePanel.
        [Inject]
        private void Constructor(IInventoryManager inventoryManager, ICollectablePanel collectablePanel)
        {
            this.inventoryManager = inventoryManager;
            this.collectablePanel = collectablePanel;
        }

        private void Start()
        {
            collectablePanel.OnItemCollect += OnItemCollected;
        }

        /// <summary>
        /// Event handler for item collection, adding the item to the player's inventory
        /// </summary>
        private void OnItemCollected(Item item)
        {
            inventoryManager.AddItem(item);
        }

        // 

        /// <summary>
        /// OnTriggerEnter is called when the Collider enters the trigger zone.
        /// </summary>
        private void OnTriggerEnter(Collider collider)
        {
            // in game you can collect item from here aswell
        }

    }
}
