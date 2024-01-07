using System.Collections;
using System.Collections.Generic;
using ObjectPool.Interface;
using Palmmedia.ReportGenerator.Core.Common;
using Unity.VisualScripting;
using UnityEngine;
using InventorySystem.Interface;
using Zenject;

namespace InventorySystem
{
    /// <summary>
    /// Manages the inventory system.
    /// </summary>
    public class InventoryManager : MonoBehaviour, IInventoryManager
    {
        /// <summary>
        /// The filename for saving and loading inventory data.
        /// </summary>
        private const string saveFileName = "InventoryData.json";

        /// <summary>
        /// Reference to the inventory user interface
        /// </summary>
        IInventoryUI inventoryUI;

        /// <summary>
        /// Reference to the object pooler for efficient item management.
        /// </summary>
        IObjectPooler objectPooler;

        /// <summary>
        /// The list of items in the inventory
        /// </summary>
        public List<Item> items { get; set; }


        /// <summary>
        /// Constructor using dependency injection to initialize.
        /// </summary>
        [Inject]
        private void Constructor(IInventoryUI inventoryUI, IObjectPooler objectPooler)
        {
            this.inventoryUI = inventoryUI;
            this.objectPooler = objectPooler;
        }

        private void Start()
        {
            items = new();
            inventoryUI.OnClearButton += Clear;
            inventoryUI.OnMergedButton += Merge;
            inventoryUI.OnRemoveItemButton += RemoveItem;
            inventoryUI.OnSaveInventoryButton += SaveInventory;
            inventoryUI.OnLoadInventoryButton += LoadInventory;
        }


        /// <summary>
        /// Adds a new item to the inventory.
        /// </summary>
        public void AddItem(Item item)
        {
            Item newItem = new(item.ItemData, item.Quantity);
            inventoryUI.AddItem(newItem);
            items.Add(newItem);
        }


        /// <summary>
        /// Merges duplicate items in the inventory, combining their quantities.
        /// </summary>
        private void Merge()
        {
            List<Item> mergedItemList = new();
            foreach (var item in items)
            {
                if (!mergedItemList.Exists(i => i.ItemData.ItemID == item.ItemData.ItemID))
                {
                    mergedItemList.Add(item);
                }
                else
                {
                    mergedItemList.Find(i => i.ItemData.ItemID == item.ItemData.ItemID).Quantity += item.Quantity;
                }
            }

            items.Clear();
            items = mergedItemList;
            inventoryUI.ReArrangeItems(items);
        }


        /// <summary>
        /// Removes a specified item from the inventory.
        /// </summary>
        private void RemoveItem(Item item)
        {
            if (item.Quantity > 1)
            {
                int index = items.IndexOf(item);
                items[index].Quantity--;
                inventoryUI.UpdateItem(items[index]);
            }
            else
            {
                items.Remove(item);
                inventoryUI.RemoveItem(item);
            }
        }


        /// <summary>
        /// Clears all items from the inventory.
        /// </summary>
        private void Clear()
        {
            items.Clear();
            inventoryUI.ClearAllItem();
        }


        /// <summary>
        /// Saves the current inventory data to a JSON file.
        /// </summary>
        private void SaveInventory()
        {
            InventoryData inventoryData = new()
            {
                items = items
            };
            var json = JsonUtility.ToJson(inventoryData);
            System.IO.File.WriteAllText(saveFileName, json);
        }


        /// <summary>
        /// Loads inventory data from a JSON file and updates the inventory.
        /// </summary>
        private void LoadInventory()
        {
            if (System.IO.File.Exists(saveFileName))
            {
                string json = System.IO.File.ReadAllText(saveFileName);
                InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
                items = inventoryData.items;
                inventoryUI.ReArrangeItems(items);
            }
        }


        /// <summary>
        /// Serializable class to represent the structure of inventory data.
        /// </summary>
        [System.Serializable]
        public class InventoryData
        {
            public List<Item> items = new();
        }
    }
}