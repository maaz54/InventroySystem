using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InventorySystem.Interface;

namespace InventorySystem
{
    public class CollectablePanel : MonoBehaviour, ICollectablePanel
    {
        [SerializeField] RectTransform slotHolder;
        [SerializeField] ItemCollectable[] itemCollectables;
        public Action<Item> OnItemCollect { get; set; }

        private void Start()
        {
            itemCollectables.ToList().ForEach(i => i.OnItemCollect += ItemCollected);
        }

        private void ItemCollected(Item item)
        {
            OnItemCollect?.Invoke(item);
        }

    }
}
