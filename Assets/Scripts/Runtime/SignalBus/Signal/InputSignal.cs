using Runtime.InputModule.Model;

namespace Runtime.SignalBus.Signal
{
    public readonly struct InputSignal
    {
        public readonly InputType InputType;

        public InputSignal(InputType inputType)
        {
            InputType = inputType;
        }
    }
}