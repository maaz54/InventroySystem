using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPool.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemSlot : MonoBehaviour, IPoolableObject
    {
        public Transform Transform => transform;
        public int ObjectID => "ItemUISlot".GetHashCode();
        [SerializeField] Button crossButton;
        [SerializeField] Button itemButton;
        [SerializeField] Image itemImage;
        [SerializeField] TextMeshProUGUI QuantityText;
        Item item;
        public Item GetItem => item;
        public Action<Item> OnCrossButton;

        public void SetItem(Item item)
        {
            this.item = item;
            UpdateVisuals();
            crossButton.onClick.RemoveAllListeners();
            crossButton.onClick.AddListener(OnCrossButtonClick);
        }

        public void UpdateVisuals()
        {
            itemImage.sprite = item.ItemData.itemSprite;
            QuantityText.text = item.Quantity.ToString();
        }

        private void OnCrossButtonClick()
        {
            OnCrossButton?.Invoke(GetItem);
        }
    }
}