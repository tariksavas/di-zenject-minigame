using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Factory
{
    public class UIPanelFactory : IFactory<string, UniTask<UIPanel>>
    {
        private readonly DiContainer _diContainer;

        public UIPanelFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public async UniTask<UIPanel> Create(string key)
        {
            GameObject loadedObject = await AssetLibrary.LoadAndGetAssetAsync<GameObject>(key);

            UIPanel uiPanel = _diContainer.InstantiatePrefabForComponent<UIPanel>(loadedObject);
            uiPanel.transform.SetAsLastSibling();

            return uiPanel;
        }
    }
}