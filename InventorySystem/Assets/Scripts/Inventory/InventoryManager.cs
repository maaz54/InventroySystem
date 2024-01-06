using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using Palmmedia.ReportGenerator.Core.Common;
using Unity.VisualScripting;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        private const string saveFileName = "InventoryData.json";
        [SerializeField] InventoryUI inventoryUI;
        [SerializeField] ObjectPooler objectPooler;
        public List<Item> items;

        private void Start()
        {
            inventoryUI.OnClearButton += Clear;
            inventoryUI.OnMergedButton += Merge;
            inventoryUI.OnRemoveItemButton += RemoveItem;
            inventoryUI.OnSaveInventoryButton += SaveInventory;
            inventoryUI.OnLoadInventoryButton += LoadInventory;
            inventoryUI.Initialize(objectPooler);
        }

        public void AddItem(Item item)
        {
            Item newItem = new(item.ItemData, item.Quantity);
            inventoryUI.AddItem(newItem);
            items.Add(newItem);
        }

        public void Merge()
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

        public void RemoveItem(Item item)
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

        public void Clear()
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