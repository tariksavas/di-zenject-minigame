using Runtime.SignalBus.Controller;
using Zenject;

namespace Runtime.SignalBus.Installer
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SignalController>().AsSingle().NonLazy();
        }
    }
}