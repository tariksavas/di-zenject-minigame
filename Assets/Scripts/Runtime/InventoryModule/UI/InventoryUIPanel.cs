using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Controller;
using Runtime.ConfigurationModule.Model;
using Runtime.InventoryModule.Controller;
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
        private readonly InventoryUIItem.Factory _inventoryItemFactory;
        
        [Inject]
        private InventoryController _inventoryController;
        
        [Inject]
        private IConfigurationController _configurationController;
        
        [SerializeField]
        private Transform _content;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            UpdateView().Forget();
        }

        public async UniTaskVoid UpdateView()
        {
            //TODO: Clear content childs
            
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