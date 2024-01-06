using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem
{
    public class CollectablePanel : MonoBehaviour
    {
        [SerializeField] RectTransform slotHolder;
        [SerializeField] ItemCollectable[] itemCollectables;
        public Action<Item> OnItemCollect;

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
