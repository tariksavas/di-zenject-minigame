using System;
using System.Collections.Generic;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
using Zenject;

namespace Runtime.InventoryModule.Controller
{
    public class InventoryController : IInitializable, IDisposable
    {
        private SignalController _signalController;

        private readonly Dictionary<int, int> _userItems = new Dictionary<int, int>();

        public InventoryController(SignalController signalController)
        {
            _signalController = signalController;
        }
        
        public void Initialize()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _signalController.Subscribe<ItemValueChangedSignal>(OnItemValueChanged);
        }
        
        public void OnItemValueChanged(ItemValueChangedSignal itemValueChangedSignal)
        {
            if (_userItems.ContainsKey(itemValueChangedSignal.Type))
            {
                _userItems[itemValueChangedSignal.Type] += itemValueChangedSignal.Value;

                if (_userItems[itemValueChangedSignal.Type] <= 0)
                {
                    _userItems.Remove(itemValueChangedSignal.Type);
                }
                
            }
            else
            {
                _userItems.Add(itemValueChangedSignal.Type, itemValueChangedSignal.Value);
            }

            _signalController.Fire(new UserItemsUpdatedSignal(_userItems));
        }

        public Dictionary<int, int> GetUserItems()
        {
            return _userItems;
        }

        private void UnsubscribeEvents()
        {
            _signalController.UnSubscribe<ItemValueChangedSignal>(OnItemValueChanged);
        }
        
        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}