using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Controller;
using Runtime.ConfigurationModule.Model;
using Runtime.InventoryModule.Controller;
using Runtime.InventoryModule.Factory;
using Runtime.InventoryModule.Model;
using Runtime.StructuralDefinitions;
using Runtime.UI;
using UnityEngine;
using Zenject;

namespace Runtime.InventoryModule.UI
{
    public class InventoryUIPanel : UIPanel
    {
        [Inject]
        private readonly InventoryItemFactory _inventoryItemFactory;
        
        [Inject]
        private InventoryController _inventoryController;
        
        [Inject]
        private IConfigurationController _configurationController;
        
        [SerializeField]
        private Transform _content;

        public async UniTaskVoid UpdateView()
        {
            OptimizedList<UserItem> userItems = _inventoryController.GetUserItems();
            
            for (int index = 0; index < userItems.Count; index++)
            {
                UserItem userItem = userItems[index];

                InventoryItemObject inventoryItemObject =
                    _configurationController.GetInventoryItemConfig<InventoryItemObject>(userItem.type);
                
                _inventoryItemFactory.Create(inventoryItemObject.imageKey, userItem.count, _content).Forget();
            }
        }
    }
}