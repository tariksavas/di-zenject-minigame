using Cysharp.Threading.Tasks;
using Runtime.CollectibleModule.Controller;
using Runtime.CollectibleModule.Factory;
using Zenject;

namespace Runtime.CollectibleModule.Installer
{
    public class CollectibleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<string, int, int, UniTask<CollectibleItem>, CollectibleItem.Factory>()
                .FromFactory<CollectibleItemFactory>();
            
            Container.Bind<CollectibleController>().AsSingle().Lazy();
        }
    }
}