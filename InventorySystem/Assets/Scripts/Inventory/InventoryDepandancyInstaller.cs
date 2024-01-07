using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using InventorySystem;
using InventorySystem.Interface;
using ObjectPool;
using ObjectPool.Interface;

namespace InventorySystem.Installer
{
    public class InventoryDepandancyInstaller : MonoInstaller<InventoryDepandancyInstaller>
    {
        [SerializeField] CollectablePanel collectablePanel;
        [SerializeField] InventoryManager inventoryManager;
        [SerializeField] InventoryUI inventoryUI;
        [SerializeField] ItemDetailPopup itemDetailPopup;
        [SerializeField] ObjectPooler objectPooler;

        public override void InstallBindings()
        {
            Container.Bind<ICollectablePanel>().FromInstance(collectablePanel).AsSingle();
            Container.Bind<IInventoryManager>().FromInstance(inventoryManager).AsSingle();
            Container.Bind<IInventoryUI>().FromInstance(inventoryUI).AsSingle();
            Container.Bind<IItemDetailPopup>().FromInstance(itemDetailPopup).AsSingle();
            Container.Bind<IObjectPooler>().FromInstance(objectPooler).AsSingle();
        }
    }
}