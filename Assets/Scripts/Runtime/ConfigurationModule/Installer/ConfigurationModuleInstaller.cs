using Runtime.ConfigurationModule.Controller;
using Zenject;

namespace Runtime.ConfigurationModule.Installer
{
    public class ConfigurationModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScriptableConfigurationController>().AsSingle().NonLazy();
        }
    }
}