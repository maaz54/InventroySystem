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
    public class InventoryManager : MonoBehaviour, IInventoryManager
    {
        private const string saveFileName = "InventoryData.json";
        IInventoryUI inventoryUI;
        IObjectPooler objectPooler;
        public List<Item> items { get; set; }

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

        public void AddItem(Item item)
        {
            Item newItem = new(item.ItemData, item.Quantity);
            inventoryUI.AddItem(newItem);
            items.Add(newItem);
        }

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

        private void Clear()
        {
            items.Clear();
            inventoryUI.ClearAllItem();
        }



        private void SaveInventory()
        {
            InventoryData inventoryData = new()
            {
                items = items
            };
            var json = JsonUtility.ToJson(inventoryData);
            System.IO.File.WriteAllText(saveFileName, json);
        }

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

        [System.Serializable]
        public class InventoryData
        {
            public List<Item> items = new();
        }
    }
}