using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectPool.Interface;
using Zenject;
using InventorySystem.Interface;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour, IInventoryUI
    {
        IItemDetailPopup itemDetailPopup;
        [SerializeField] ItemSlot itemSlotPrefab;
        [SerializeField] RectTransform itemSlotHolder;
        [SerializeField] List<ItemSlot> itemSlots;
        [SerializeField] Button clearButton;
        [SerializeField] Button mergedButton;
        [SerializeField] Button saveButton;
        [SerializeField] Button LoadButton;
        public Action OnClearButton { get; set; }
        public Action OnMergedButton { get; set; }
        public Action OnSaveInventoryButton { get; set; }
        public Action OnLoadInventoryButton { get; set; }
        public Action<Item> OnRemoveItemButton { get; set; }
        IObjectPooler objectPooler;

        [Inject]
        private void Constructor(IObjectPooler objectPooler, IItemDetailPopup itemDetailPopup)
        {
            this.objectPooler = objectPooler;
            this.itemDetailPopup = itemDetailPopup;
            Initialize();
        }

        void Initialize()
        {
            clearButton.onClick.AddListener(OnClearButtonClicked);
            mergedButton.onClick.AddListener(OnMergedButtonClicked);
            saveButton.onClick.AddListener(SaveInventoryButton);
            LoadButton.onClick.AddListener(LoadInventoryButton);
        }

        public void SaveInventoryButton()
        {
            OnSaveInventoryButton?.Invoke();
        }

        public void LoadInventoryButton()
        {
            OnLoadInventoryButton?.Invoke();
        }

        public void AddItem(Item item)
        {
            ItemSlot itemSlot = objectPooler.Pool<ItemSlot>(itemSlotPrefab, itemSlotHolder);
            itemSlot.SetItem(item);
            itemSlot.OnCrossButton = OnItemRemoveClicked;
            itemSlot.OnItemButton = OnItemCLick;
            itemSlots.Add(itemSlot);
        }

        private void OnItemCLick(Item item)
        {
            itemDetailPopup.EnablePopup(item);
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