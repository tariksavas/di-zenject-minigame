using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Config;
using Runtime.InventoryModule.Controller;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule
{
    public class CollectibleItem : MonoBehaviour
    {
        [Inject] 
        private readonly InventoryController _inventoryController;
        
        public int type;
        public int count;
        
        [Inject]
        public void Construct(int type, int count)
        {
            this.type = type;
            this.count = count;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagConfig.PLAYER_TAG))
            {
                _inventoryController.AddUserItem(type, count);
            }
        }

        public class Factory : PlaceholderFactory<string, int, int, UniTask<CollectibleItem>> { }
    }
}