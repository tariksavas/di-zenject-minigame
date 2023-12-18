using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule.Factory
{
    public class CollectibleItemFactory : IFactory<string, int, int, Vector3, UniTask<CollectibleItem>>
    {     
        private readonly DiContainer _diContainer;

        public CollectibleItemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public async UniTask<CollectibleItem> Create(string assetKey, int type, int value, Vector3 position)
        {
            GameObject loadedObject = await AssetLibrary.LoadAndGetAssetAsync<GameObject>(assetKey);

            CollectibleItem collectibleItem = _diContainer.InstantiatePrefabForComponent<CollectibleItem>(loadedObject,
                new object[] { type, value });
            collectibleItem.transform.position = position;

            return collectibleItem;
        }
    }
}