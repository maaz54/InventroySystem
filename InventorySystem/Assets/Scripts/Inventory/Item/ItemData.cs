using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public int ItemID { get; set; }
        [field: SerializeField] public string itemName { get; set; }
        [field: SerializeField] public Sprite itemSprite { get; set; }
        [field: SerializeField] public ItemType itemType { get; set; }
        [field: SerializeField] public float weight { get; set; }

    }
}