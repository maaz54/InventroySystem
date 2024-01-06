using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Gun", order = 1)]
    public class GunItemData : ItemData
    {
        public GunType GunType;
        public BulletItemData bulletType;
    }

    public enum GunType
    {
        HandGun,
        rifle,
        ShotGun,
        Sniper
    }
}