using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectPool.Interface;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] ItemSlot itemSlotPrefab;
        [SerializeField] RectTransform itemSlotHolder;
        [SerializeField] List<ItemSlot> itemSlots;
        [SerializeField] Button clearButton;
        [SerializeField] Button mergedButton;
        public Action OnClearButton;
        public Action OnMergedButton;
        public Action<Item> OnRemoveItemButton;
        IObjectPooler objectPooler;

        public void Initialize(IObjectPooler objectPooler)
        {
            this.objectPooler = objectPooler;
            clearButton.onClick.AddListener(OnClearButtonClicked);
            mergedButton.onClick.AddListener(OnMergedButtonClicked);
        }

        public void AddItem(Item item)
        {
            // ItemSlot itemSlot = Instantiate(itemSlotPrefab, itemSlotHolder);
            ItemSlot itemSlot = objectPooler.Pool<ItemSlot>(itemSlotPrefab, itemSlotHolder);
            itemSlot.SetItem(item);
            itemSlot.OnCrossButton = OnItemRemoveClicked;
            itemSlots.Add(itemSlot);
        }

        public void RemoveItem(Item item)
        {
            ItemSlot itemSlot = itemSlots.Find(i => i.GetItem == item);
            itemSlots.Remove(itemSlot);
            objectPooler.Remove(itemSlot);
        }

        public void UpdateItem(Item item)
        {
            itemSlots.Find(i => i.GetItem == item).UpdateVisuals();
        }

        public void ReArrangeItems(List<Item> items)
        {
            ClearAllItem();
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void ClearAllItem()
        {
            // itemSlots.ForEach(i => Destroy(i.gameObject));
            itemSlots.ForEach(i => objectPooler.Remove(i));
            itemSlots.Clear();
        }

        private void OnItemRemoveClicked(Item item)
        {
            OnRemoveItemButton?.Invoke(item);
        }

        private void OnClearButtonClicked()
        {
            OnClearButton?.Invoke();
        }

        private void OnMergedButtonClicked()
        {
            OnMergedButton?.Invoke();
        }
    }
}