using Runtime.GameInteractionModule.Controller;
using Zenject;

namespace Runtime.GameInteractionModule.Installer
{
    public class GameModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameInteractionController>().AsSingle().NonLazy();
        }
    }
}