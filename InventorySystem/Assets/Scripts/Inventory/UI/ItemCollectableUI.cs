using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    /// <summary>
    /// Represents a collectable item in the UI with additional visual elements.
    /// </summary>
    public class ItemCollectableUI : ItemCollectable
    {
        /// <summary>
        /// Button for interacting with the collectable item
        /// </summary>
        [SerializeField] Button itemButton;

        /// <summary>
        /// Image to display the item's sprite.
        /// </summary>
        [SerializeField] Image itemImage;

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// Initialization method to set up button click listener and display the item's sprite.
        /// </summary>
        private void Initialize()
        {
            itemButton.onClick.AddListener(OnItemClick);
            itemImage.sprite = item.ItemData.itemSprite;
        }

        /// <summary>
        /// Event handler for the item button click, triggering item collection.
        /// </summary>
        private void OnItemClick()
        {
            CollectItem();
        }

    }
}