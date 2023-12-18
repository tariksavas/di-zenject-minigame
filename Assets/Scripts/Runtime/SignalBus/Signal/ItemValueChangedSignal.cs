namespace Runtime.SignalBus.Signal
{
    public readonly struct ItemValueChangedSignal
    {
        public readonly int Type;
        public readonly int Value;

        public ItemValueChangedSignal(int type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}