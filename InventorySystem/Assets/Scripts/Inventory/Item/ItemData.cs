using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Represents the data for a generic item, derived from ScriptableObject.
    /// </summary>

    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
    public class ItemData : ScriptableObject
    {
        /// <summary>
        /// The unique identifier for the item.
        /// </summary>
        [field: SerializeField] public int ItemID { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        [field: SerializeField] public string itemName { get; set; }

        /// <summary>
        /// The sprite representing the item.
        /// </summary>
        [field: SerializeField] public Sprite itemSprite { get; set; }

        /// <summary>
        /// The type of the item
        /// </summary>
        [field: SerializeField] public ItemType itemType { get; set; }

        /// <summary>
        /// The weight of the item
        /// </summary>
        [field: SerializeField] public float weight { get; set; }

    }
}