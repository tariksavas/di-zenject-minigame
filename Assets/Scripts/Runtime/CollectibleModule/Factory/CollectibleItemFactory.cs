using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using Runtime.CollectibleModule.Model;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule.Factory
{
    public class CollectibleItemFactory : IFactory<string, int, int,Transform, UniTask<CollectibleItem>>
    {     
        private readonly DiContainer _diContainer;

        public CollectibleItemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public async UniTask<CollectibleItem> Create(string assetKey, int type, int count, Transform parent)
        {
            GameObject prefab = await AssetLibrary.LoadAndGetAssetAsync<GameObject>(assetKey);

            return _diContainer.InstantiatePrefabForComponent<CollectibleItem>(prefab, parent, new object[] { type, count});
            
        }
    }
}