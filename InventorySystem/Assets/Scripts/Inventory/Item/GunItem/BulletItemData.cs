using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Represents the data for a bullet item, derived from the base ItemData class.
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Bullet", order = 1)]
    public class BulletItemData : ItemData
    {
        public BulletType bulletType;
    }

    /// <summary>
    /// Enumerates different types of bullets.
    /// </summary>
    public enum BulletType
    {
        Bullet9mm,
        Bullet7mm,
        BulletSlugs,
        Caliber50
    }
}