using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Represents the data for a gun item, derived from the base ItemData class.
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "Inventory/Gun", order = 1)]
    public class GunItemData : ItemData
    {
        public GunType GunType;

        /// <summary>
        /// The bullet data associated with the gun.
        /// </summary>
        public BulletItemData bulletType;
    }

    /// <summary>
    /// Enumerates different types of guns.
    /// </summary>
    public enum GunType
    {
        HandGun,
        rifle,
        ShotGun,
        Sniper
    }
}