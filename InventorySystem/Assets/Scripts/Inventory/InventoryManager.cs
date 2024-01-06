using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] InventoryUI inventoryUI;
        [SerializeField] ObjectPooler objectPooler;
        [SerializeField] private List<Item> items = new List<Item>();

        private void Start()
        {
            inventoryUI.OnClearButton += Clear;
            inventoryUI.OnMergedButton += Merge;
            inventoryUI.OnRemoveItemButton += RemoveItem;
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
            // if (item.Quantity > 1)
            // {
            //     items[items.IndexOf(item)].Quantity--;
            //     inventoryUI.UpdateItem(item);
            // }
            // else
            // {
            items.Remove(item);
            inventoryUI.RemoveItem(item);
            // }
        }

        public void Clear()
        {
            items.Clear();
            inventoryUI.ClearAllItem();
        }
    }
}