using System.Collections.Generic;

namespace Runtime.SignalBus.Signal
{
    public readonly struct UserItemsUpdatedSignal
    {
        public readonly Dictionary<int, int> UserItems;

        public UserItemsUpdatedSignal(Dictionary<int, int> userItems)
        {
            UserItems = userItems;
        }
    }
}