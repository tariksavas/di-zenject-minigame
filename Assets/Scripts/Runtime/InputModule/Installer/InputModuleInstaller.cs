using Runtime.InputModule.Controller;
using Zenject;

namespace Runtime.InputModule.Installer
{
    public class InputModuleInstaller : Installer<InputModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
        }
    }
}