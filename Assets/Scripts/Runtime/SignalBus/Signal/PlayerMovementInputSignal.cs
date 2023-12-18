using UnityEngine;

namespace Runtime.SignalBus.Signal
{
    public readonly struct PlayerMovementInputSignal
    {
        public readonly Vector3 Axis;

        public PlayerMovementInputSignal(Vector3 axis)
        {
            Axis = axis;
        }
    }
}