using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using InventorySystem.Interface;

namespace InventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        IInventoryManager inventoryManager;
        ICollectablePanel collectablePanel;

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

        private void OnItemCollected(Item item)
        {
            inventoryManager.AddItem(item);
        }

        private void OnTriggerEnter(Collider collider)
        {
            // in game you can collect item from here aswell
        }

    }
}
