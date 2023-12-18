using Runtime.GameInteractionModule.Controller;
using Zenject;

namespace Runtime.GameInteractionModule.Installer
{
    public class GameModuleInstaller : Installer<GameModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameInteractionController>().AsSingle().NonLazy();
        }
    }
}