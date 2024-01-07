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
    /// <summary>
    /// Represents the user interface for managing and displaying the inventory.
    /// </summary>
    public class InventoryUI : MonoBehaviour, IInventoryUI
    {
        /// <summary>
        /// Reference to the item detail popup
        /// </summary>
        IItemDetailPopup itemDetailPopup;

        /// <summary>
        /// Prefab for item slots
        /// </summary>
        [SerializeField] ItemSlot itemSlotPrefab;

        /// <summary>
        /// RectTransform to hold the item slots
        /// </summary>
        [SerializeField] RectTransform itemSlotHolder;

        /// <summary>
        /// List to store the instantiated item slots
        /// </summary>
        [SerializeField] List<ItemSlot> itemSlots;

        [SerializeField] Button clearButton;
        [SerializeField] Button mergedButton;
        [SerializeField] Button saveButton;
        [SerializeField] Button LoadButton;

        /// <summary>
        /// triggered by Clear button clicks
        /// </summary>
        public Action OnClearButton { get; set; }

        /// <summary>
        /// triggered by Merged button clicks
        /// </summary>
        public Action OnMergedButton { get; set; }

        /// <summary>
        /// triggered by Save button clicks
        /// </summary>
        public Action OnSaveInventoryButton { get; set; }

        /// <summary>
        /// triggered by Load button clicks
        /// </summary>
        public Action OnLoadInventoryButton { get; set; }

        /// <summary>
        /// triggered by Remove Item button clicks
        /// </summary>
        public Action<Item> OnRemoveItemButton { get; set; }

        /// <summary>
        /// Object pooler for efficient management of item slots
        /// </summary>
        IObjectPooler objectPooler;

        [Inject]
        private void Constructor(IObjectPooler objectPooler, IItemDetailPopup itemDetailPopup)
        {
            this.objectPooler = objectPooler;
            this.itemDetailPopup = itemDetailPopup;
            Initialize();
        }

        /// <summary>
        /// Initialization method to set up button click listeners
        /// </summary>
        void Initialize()
        {
            clearButton.onClick.AddListener(OnClearButtonClicked);
            mergedButton.onClick.AddListener(OnMergedButtonClicked);
            saveButton.onClick.AddListener(SaveInventoryButton);
            LoadButton.onClick.AddListener(LoadInventoryButton);
        }

        /// <summary>
        /// Button click handler for the Save Inventory button
        /// </summary>
        public void SaveInventoryButton()
        {
            OnSaveInventoryButton?.Invoke();
        }

        /// <summary>
        /// Button click handler for the Load Inventory button
        /// </summary>
        public void LoadInventoryButton()
        {
            OnLoadInventoryButton?.Invoke();
        }

        /// <summary>
        /// Adds a new item to the inventory UI
        /// </summary>
        public void AddItem(Item item)
        {
            ItemSlot itemSlot = objectPooler.Pool<ItemSlot>(itemSlotPrefab, itemSlotHolder);
            itemSlot.SetItem(item);
            itemSlot.OnCrossButton = OnItemRemoveClicked;
            itemSlot.OnItemButton = OnItemCLick;
            itemSlots.Add(itemSlot);
        }

        /// <summary>
        /// Event handler for item clicks, showing details in the item detail popup.
        /// </summary>
        private void OnItemCLick(Item item)
        {
            itemDetailPopup.EnablePopup(item);
        }

        /// <summary>
        /// Removes an item from the inventory UI.
        /// </summary>
        public void RemoveItem(Item item)
        {
            ItemSlot itemSlot = itemSlots.Find(i => i.GetItem == item);
            itemSlots.Remove(itemSlot);
            objectPooler.Remove(itemSlot);
        }

        /// <summary>
        /// Updates the visual representation of an item in the UI.
        /// </summary>
        public void UpdateItem(Item item)
        {
            itemSlots.Find(i => i.GetItem == item).UpdateVisuals();
        }

        /// <summary>
        /// Rearranges items in the UI based on a new list of items.
        /// </summary>
        public void ReArrangeItems(List<Item> items)
        {
            ClearAllItem();
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        /// <summary>
        /// Clears all items from the inventory UI.
        /// </summary>
        public void ClearAllItem()
        {
            itemSlots.ForEach(i => objectPooler.Remove(i));
            itemSlots.Clear();
        }

        /// <summary>
        /// Event handler for item removal, triggered when the cross button is clicked.
        /// </summary>
        private void OnItemRemoveClicked(Item item)
        {
            OnRemoveItemButton?.Invoke(item);
        }

        /// <summary>
        /// Event handler for the Clear button click
        /// </summary>
        private void OnClearButtonClicked()
        {
            OnClearButton?.Invoke();
        }

        /// <summary>
        /// Event handler for the Merge button click.
        /// </summary>
        private void OnMergedButtonClicked()
        {
            OnMergedButton?.Invoke();
        }
    }
}