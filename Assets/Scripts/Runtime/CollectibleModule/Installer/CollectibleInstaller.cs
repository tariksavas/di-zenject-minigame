using Cysharp.Threading.Tasks;
using Runtime.CollectibleModule.Factory;
using Runtime.CollectibleModule.Model;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule.Installer
{
    public class CollectibleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<string, int, int, Transform, UniTask<CollectibleItem>, CollectibleItem.Factory>()
                .FromFactory<CollectibleItemFactory>();
            
            Container.Bind<CollectibleHandler>().AsSingle().Lazy();
        }
    }
}