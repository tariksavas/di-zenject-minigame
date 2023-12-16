using Cysharp.Threading.Tasks;
using Runtime.UI.Controller;
using Runtime.UI.Factory;
using Zenject;

namespace Runtime.UI.Installer
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<string, UniTask<UIPanel>, UIPanel.Factory>()
                .FromFactory<UIPanelFactory>();
            
            Container.Bind<UIPanelController>().AsSingle().Lazy();
        }
    }
}