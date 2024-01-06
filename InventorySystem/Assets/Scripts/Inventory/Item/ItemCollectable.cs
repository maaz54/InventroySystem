using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class ItemCollectable : MonoBehaviour
    {
        [SerializeField] internal Item item;
        public Action<Item> OnItemCollect;

        internal void CollectItem()
        {
            OnItemCollect?.Invoke(item);
        }
    }
}