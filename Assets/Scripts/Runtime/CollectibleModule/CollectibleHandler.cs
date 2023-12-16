using Cysharp.Threading.Tasks;
using Runtime.CollectibleModule.Factory;
using Runtime.ConfigurationModule.Controller;
using Runtime.ConfigurationModule.Model;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule
{
    public class CollectibleHandler : MonoBehaviour
    {
        [Inject] 
        private readonly IConfigurationController _configurationController;
        
        [Inject]
        private readonly CollectibleItemFactory _collectibleItemFactory;

        private void Start()
        {
            PlaceObjects();
        }

        public void PlaceObjects()
        {
            CollectibleItemObject[] collectibleItemObjects =
                _configurationController.GetCollectibleItemConfigs<CollectibleItemObject>();

            for (int index = 0; index < collectibleItemObjects.Length; index++)
            {
                CollectibleItemObject collectibleItemObject = collectibleItemObjects[index];

                int randomItemCount = Random.Range(collectibleItemObject.minCount, collectibleItemObject.maxCount);

                _collectibleItemFactory.Create(collectibleItemObject.assetKey, collectibleItemObject.type,
                    randomItemCount, transform).Forget();
            }
        }
    }
}