using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Bullet", order = 1)]
    public class BulletItemData : ItemData
    {
        public BulletType bulletType;   
    }

    public enum BulletType
    {
        Bullet9mm,
        Bullet7mm,
        BulletSlugs,
        Caliber50
    }
}