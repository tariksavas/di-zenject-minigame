using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using Runtime.InventoryModule.UI;
using UnityEngine;
using Zenject;

namespace Runtime.InventoryModule.Factory
{
    public class InventoryItemFactory : IFactory<string, int, Transform, UniTask<InventoryUIItem>>
    {
        private const string INVENTORY_ITEM_KEY = "InventoryItem";
        
        private readonly DiContainer _diContainer;

        public InventoryItemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public async UniTask<InventoryUIItem> Create(string imageKey, int count, Transform content)
        {
            GameObject prefab = await AssetLibrary.LoadAndGetAssetAsync<GameObject>(INVENTORY_ITEM_KEY);

            return _diContainer.InstantiatePrefabForComponent<InventoryUIItem>(prefab, content, new object[] { imageKey, count });
        }
    }
}