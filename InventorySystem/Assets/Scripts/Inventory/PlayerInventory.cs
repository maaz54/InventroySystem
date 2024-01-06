using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

namespace InventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] InventoryManager inventoryManager;
        [SerializeField] CollectablePanel collectablePanel;

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
            // 
        }

    }
}
