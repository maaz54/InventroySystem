using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem.Interface;

namespace InventorySystem
{
    /// <summary>
    /// Represents a popup displaying detailed information about an item.
    /// </summary>
    public class ItemDetailPopup : MonoBehaviour, IItemDetailPopup
    {
        /// <summary>
        /// Text for displaying Item Name
        /// </summary>
        [SerializeField] TextMeshProUGUI itemNameText;

        /// <summary>
        /// Text for displaying Item Type
        /// </summary>
        [SerializeField] TextMeshProUGUI itemTypeText;

        /// <summary>
        /// Text for displaying Item Weigth
        /// </summary>
        [SerializeField] TextMeshProUGUI itemWeightText;

        /// <summary>
        /// Image for displaying Item Image
        /// </summary>
        [SerializeField] Image itemImage;

        /// <summary>
        /// Close button
        /// </summary>
        [SerializeField] Button crossButton;

        private void Awake()
        {
            crossButton.onClick.AddListener(DisablePopup);
        }

        /// <summary>
        /// Enables the popup and initializes it with item details
        /// </summary>
        /// <param name="item"></param>
        public void EnablePopup(Item item)
        {
            gameObject.SetActive(true);
            Initialize(item);
        }

        /// <summary>
        /// Initializes the popup with details from the provided item
        /// </summary>
        private void Initialize(Item item)
        {
            itemNameText.text = "Name: " + item.ItemData.name;
            itemTypeText.text = "Type: " + item.ItemData.itemType.ToString();
            itemWeightText.text = "Weigth: " + item.ItemData.weight.ToString();
            itemImage.sprite = item.ItemData.itemSprite;
        }

        /// <summary>
        /// Disables the popup, hiding it from view.
        /// </summary>
        public void DisablePopup()
        {
            gameObject.SetActive(false);
        }

    }

}