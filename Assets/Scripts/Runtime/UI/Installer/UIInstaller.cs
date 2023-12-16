using Runtime.UI.Controller;
using Zenject;

namespace Runtime.UI.Installer
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIPanelController>().AsSingle().NonLazy();
        }
    }
}