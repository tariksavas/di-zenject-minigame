using Runtime.ConfigurationModule.Config;
using Runtime.InputModule.Model;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
using UnityEngine;
using Zenject;

namespace Runtime.InputModule.Controller
{
    public class InputController : ITickable
    {
        private readonly SignalController _signalController;

        public InputController(SignalController signalController)
        {
            _signalController = signalController;
        }
        
        public void Tick()
        {
            for (int index = 0; index < KeyCodeConfigs.INVENTORY_OPEN_CLOSE_BUTTONS.Count; index++)
            {
                if (Input.GetKeyDown(KeyCodeConfigs.INVENTORY_OPEN_CLOSE_BUTTONS[index]))
                {
                    _signalController.Fire(new InputSignal(InputType.InventoryOpenClose));
                }

                _signalController.Fire(new PlayerMovementInputSignal(new Vector3(Input.GetAxis("Horizontal"), 0,
                    Input.GetAxis("Vertical"))));
            }
        }
    }
}