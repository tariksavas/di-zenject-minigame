using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.UI.Factory;
using Zenject;

namespace Runtime.UI.Controller
{
    public class UIPanelController
    {
        [Inject]
        private UIPanelFactory _uiPanelFactory;

        public async UniTask<T> GetPanelAsync<T>(string key, CancellationToken cancellationToken = default) where T : UIPanel
        {
            UIPanel uiPanel = await _uiPanelFactory.Create(key);

            return uiPanel as T;
        }
    }
}