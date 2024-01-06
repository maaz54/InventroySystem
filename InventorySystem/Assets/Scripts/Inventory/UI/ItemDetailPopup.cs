using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemDetailPopup : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI itemNameText;
        [SerializeField] TextMeshProUGUI itemTypeText;
        [SerializeField] TextMeshProUGUI itemWeightText;
        [SerializeField] Image itemImage;
        [SerializeField] Button crossButton;

        private void Awake()
        {
            crossButton.onClick.AddListener(DisablePopup);
        }

        public void EnablePopup(Item item)
        {
            gameObject.SetActive(true);
            Initialize(item);
        }

        private void Initialize(Item item)
        {
            itemNameText.text = "Name: " + item.ItemData.name;
            itemTypeText.text = "Type: " + item.ItemData.itemType.ToString();
            itemWeightText.text = "Weigth: " + item.ItemData.weight.ToString();
            itemImage.sprite = item.ItemData.itemSprite;
        }

        public void DisablePopup()
        {
            gameObject.SetActive(false);
        }

    }

}