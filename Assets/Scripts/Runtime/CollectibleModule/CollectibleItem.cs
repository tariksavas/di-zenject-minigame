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
        
        private int _type;
        private int _count;
        
        [Inject]
        public void Construct(int type, int count)
        {
            _type = type;
            _count = count;
        }

        private void Start()
        {
            _inventoryController.AddUserItem(_type, _count);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagConfig.PLAYER_TAG))
            {
                _inventoryController.AddUserItem(_type, _count);
            }
        }

        public class Factory : PlaceholderFactory<string, int, int, UniTask<CollectibleItem>> { }
    }
}