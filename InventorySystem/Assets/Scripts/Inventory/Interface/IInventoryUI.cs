using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Interface
{
    public interface IInventoryUI
    {
        Action OnClearButton { get; set; }
        Action OnMergedButton { get; set; }
        Action OnSaveInventoryButton { get; set; }
        Action OnLoadInventoryButton { get; set; }
        Action<Item> OnRemoveItemButton { get; set; }
        void SaveInventoryButton();
        void LoadInventoryButton();
        void AddItem(Item item);
        void RemoveItem(Item item);
        void UpdateItem(Item item);
        void ReArrangeItems(List<Item> items);
        void ClearAllItem();
    }
}