using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using Zenject;

namespace Runtime.UI.Factory
{
    public class UIPanelFactory : IFactory<string, UniTask<UIPanel>>
    {
        public async UniTask<UIPanel> Create(string key)
        {
            UIPanel uiPanel = await AssetLibrary.LoadAndGetAssetAsync<UIPanel>(key);

            return uiPanel;
        }
    }
}