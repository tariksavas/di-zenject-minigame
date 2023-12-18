using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Controller;
using Runtime.ConfigurationModule.Model;
using Runtime.InventoryModule.Controller;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
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
        private SignalController _signalController;
        
        [Inject]
        private IConfigurationController _configurationController;
        
        [SerializeField]
        private Transform _content;

        private readonly Dictionary<int, InventoryUIItem> _cachedUserItems = new Dictionary<int, InventoryUIItem>();

        protected override void Awake()
        {
            base.Awake();

            UpdateViewInit();
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            
            _signalController.Subscribe<UserItemsUpdatedSignal>(UpdateView);
        }

        private void UpdateViewInit()
        {
            Dictionary<int, int> userItems = _inventoryController.GetUserItems();
            UpdateView(new UserItemsUpdatedSignal(userItems));
        }
        
        private void UpdateView(UserItemsUpdatedSignal userItemsUpdatedSignal)
        {
            foreach (int key in userItemsUpdatedSignal.UserItems.Keys)
            {
                int type = key;
                int value = userItemsUpdatedSignal.UserItems[key];
                
                if (_cachedUserItems.TryGetValue(type, out InventoryUIItem cachedUserItem))
                {
                    if (value <= 0)
                    {
                        _cachedUserItems.Remove(type);
                        Destroy(cachedUserItem);
                    }
                    else
                    {
                        cachedUserItem.UpdateCount(value);
                    }
                
                    continue;
                }

                CreateInventoryUIItem(type, value).Forget();
            }
        }

        private async UniTaskVoid CreateInventoryUIItem(int type, int value)
        {
            InventoryItemObject inventoryItemObject =
                _configurationController.GetInventoryItemConfig<InventoryItemObject>(type);

            InventoryUIItem inventoryUIItem =
                await _inventoryItemFactory.Create(inventoryItemObject.imageKey, value, _content);

            _cachedUserItems.Add(type, inventoryUIItem);
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            
            _signalController.UnSubscribe<UserItemsUpdatedSignal>(UpdateView);
        }
    }
}