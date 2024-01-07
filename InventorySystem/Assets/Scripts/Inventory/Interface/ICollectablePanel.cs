using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Interface
{
    public interface ICollectablePanel
    {
        Action<Item> OnItemCollect { get; set; }
    }
}