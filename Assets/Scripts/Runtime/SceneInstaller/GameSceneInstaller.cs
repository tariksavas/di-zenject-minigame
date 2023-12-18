using Runtime.CollectibleModule.Installer;
using Runtime.GameInteractionModule.Installer;
using Runtime.InputModule.Installer;
using Runtime.InventoryModule.Installer;
using Runtime.PlayerMovementModule.Installer;
using Zenject;

namespace Runtime.SceneInstaller
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameModuleInstaller.Install(Container);
            
            InputModuleInstaller.Install(Container);
            
            PlayerMovementInstaller.Install(Container);
            
            CollectibleInstaller.Install(Container);
            
            InventoryInstaller.Install(Container);
        }
    }
}