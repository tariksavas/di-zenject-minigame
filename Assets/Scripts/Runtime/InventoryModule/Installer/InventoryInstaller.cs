using Cysharp.Threading.Tasks;
using Runtime.InventoryModule.Controller;
using Runtime.InventoryModule.Factory;
using Runtime.InventoryModule.UI;
using UnityEngine;
using Zenject;

namespace Runtime.InventoryModule.Installer
{
    public class InventoryInstaller : Installer<InventoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InventoryController>().AsSingle().NonLazy();

            Container.BindFactory<string, int, Transform, UniTask<InventoryUIItem>, InventoryUIItem.Factory>()
                .FromFactory<InventoryItemFactory>();
        }
    }
}