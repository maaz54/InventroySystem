using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Interface
{
    public interface IItemDetailPopup
    {
        void EnablePopup(Item item);
        void DisablePopup();
    }
}
