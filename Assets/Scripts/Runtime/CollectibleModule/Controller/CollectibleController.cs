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
            MapRangeObject mapRangeObject = _configurationController.GetMapRangeConfig<MapRangeObject>(0);

            CollectibleItemObject[] collectibleItemObjects =
                _configurationController.GetCollectibleItemConfigs<CollectibleItemObject>();

            for (int index = 0; index < collectibleItemObjects.Length; index++)
            {
                CollectibleItemObject collectibleItemObject = collectibleItemObjects[index];

                int randomItemCount = Random.Range(collectibleItemObject.minCount, collectibleItemObject.maxCount);

                for (int countIndex = 0; countIndex < randomItemCount; countIndex++)
                {
                    int randomItemValue = Random.Range(collectibleItemObject.minValue, collectibleItemObject.maxValue);

                    Vector3 randomPosition = new Vector3(Random.Range(mapRangeObject.minX, mapRangeObject.maxX),
                        mapRangeObject.fixedY, Random.Range(mapRangeObject.minZ, mapRangeObject.maxZ));

                    _collectibleItemFactory.Create(collectibleItemObject.assetKey, collectibleItemObject.type,
                        randomItemValue, randomPosition).Forget();
                }
            }
        }
    }
}