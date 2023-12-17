using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Controller;
using Runtime.ConfigurationModule.Model;
using UnityEngine;

namespace Runtime.CollectibleModule.Controller
{
    public class CollectibleController
    {
        private readonly IConfigurationController _configurationController;

        private readonly CollectibleItem.Factory _collectibleItemFactory;

        public CollectibleController(IConfigurationController configurationController, CollectibleItem.Factory collectibleItemFactory)
        {
            _configurationController = configurationController;
            _collectibleItemFactory = collectibleItemFactory;

            PlaceObjects();
        }

        private void PlaceObjects()
        {
            CollectibleItemObject[] collectibleItemObjects =
                _configurationController.GetCollectibleItemConfigs<CollectibleItemObject>();

            for (int index = 0; index < collectibleItemObjects.Length; index++)
            {
                CollectibleItemObject collectibleItemObject = collectibleItemObjects[index];

                int randomItemCount = Random.Range(collectibleItemObject.minCount, collectibleItemObject.maxCount);

                _collectibleItemFactory.Create(collectibleItemObject.assetKey, collectibleItemObject.type,
                    randomItemCount).Forget();
            }
        }
    }
}