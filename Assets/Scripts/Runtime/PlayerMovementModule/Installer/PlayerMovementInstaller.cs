using Runtime.PlayerMovementModule.Controller;
using Zenject;

namespace Runtime.PlayerMovementModule.Installer
{
    public class PlayerMovementInstaller : Installer<PlayerMovementInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle().NonLazy();
        }
    }
}