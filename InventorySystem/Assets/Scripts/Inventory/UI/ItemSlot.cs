using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPool.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    /// <summary>
    /// Represents a slot in the UI for displaying and interacting with items.
    /// </summary>
    public class ItemSlot : MonoBehaviour, IPoolableObject
    {
        /// <summary>
        /// Returns the Transform
        /// </summary>
        public Transform Transform => transform;

        /// <summary>
        /// Return Id of this current object
        /// </summary>
        public int ObjectID => "ItemUISlot".GetHashCode();

        /// <summary>
        /// represent close button
        /// </summary>
        [SerializeField] Button crossButton;

        /// <summary>
        /// represent Item button
        /// </summary>
        [SerializeField] Button itemButton;

        /// <summary>
        /// represent image of item
        /// </summary>
        [SerializeField] Image itemImage;

        /// <summary>
        /// text for represent quantity of item 
        /// </summary>
        [SerializeField] TextMeshProUGUI QuantityText;

        /// <summary>
        /// item associated with the slot 
        /// </summary>
        Item item;

        /// <summary>
        /// Return the current item associated with the slot
        /// </summary>
        public Item GetItem => item;

        /// <summary>
        /// triggered by cross button clicks
        /// </summary>
        public Action<Item> OnCrossButton;

        /// <summary>
        /// triggered by item button clicks
        /// </summary>
        public Action<Item> OnItemButton;

        /// <summary>
        /// Sets the item for the slot
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(Item item)
        {
            this.item = item;
            UpdateVisuals();
            crossButton.onClick.RemoveAllListeners();
            crossButton.onClick.AddListener(OnCrossButtonClick);
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(OnItemButtonClick);
        }

        /// <summary>
        /// Updates the visual representation of the item in the slot
        /// </summary>
        public void UpdateVisuals()
        {
            itemImage.sprite = item.ItemData.itemSprite;
            QuantityText.text = item.Quantity.ToString();
        }

        /// <summary>
        /// Event handler for the cross button click, triggering item removal.
        /// </summary>
        private void OnCrossButtonClick()
        {
            OnCrossButton?.Invoke(GetItem);
        }

        /// <summary>
        /// Event handler for the item button click, triggering additional actions.
        /// </summary>
        private void OnItemButtonClick()
        {
            OnItemButton?.Invoke(GetItem);
        }
    }
}