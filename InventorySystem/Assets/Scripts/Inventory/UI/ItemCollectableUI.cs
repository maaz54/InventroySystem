using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemCollectableUI : ItemCollectable
    {
        [SerializeField] Button itemButton;
        [SerializeField] Image itemImage;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            itemButton.onClick.AddListener(OnItemClick);
            itemImage.sprite = item.ItemData.itemSprite;
        }

        public void OnItemClick()
        {
            CollectItem();
        }

    }
}