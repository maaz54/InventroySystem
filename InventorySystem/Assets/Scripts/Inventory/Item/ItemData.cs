using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
    public class ItemData : ScriptableObject
    {
        public int ItemID;
        public string itemName;
        public Sprite itemSprite;
        public ItemType itemType;
        public float weight;
        
    }
}