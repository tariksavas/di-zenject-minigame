using Cysharp.Threading.Tasks;
using Runtime.InputModule.Model;
using Runtime.InventoryModule.UI;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
using Runtime.UI;
using Runtime.UI.Controller;
using Zenject;

namespace Runtime.GameInteractionModule.UI
{
    public class GameUIPanel : UIPanel
    {
        [Inject]
        private readonly SignalController _signalController;
        
        [Inject]
        private readonly UIPanelController _uiPanelController;
        
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            
            _signalController.Subscribe<InputSignal>(OnInputFired);
        }

        private void OnInputFired(InputSignal inputSignal)
        {
            OnInputFiredAsync(inputSignal).Forget();
        }

        private async UniTaskVoid OnInputFiredAsync(InputSignal inputSignal)
        {
            if (inputSignal.InputType is InputType.InventoryOpenClose)
            {
                InventoryUIPanel inventoryPanel = await _uiPanelController.GetPanelAsync<InventoryUIPanel>();
                inventoryPanel.ShowAndHidePanel();
            }
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            
            _signalController.UnSubscribe<InputSignal>(OnInputFired);
        }
    }
}