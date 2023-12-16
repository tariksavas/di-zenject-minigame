using Runtime.InputModule.Controller;
using Zenject;

namespace Runtime.InputModule.Installer
{
    public class InputModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputController>().AsSingle().NonLazy();
        }
    }
}