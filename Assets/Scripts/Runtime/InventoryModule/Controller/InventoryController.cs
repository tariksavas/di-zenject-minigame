using Runtime.InventoryModule.Model;
using Runtime.StructuralDefinitions;

namespace Runtime.InventoryModule.Controller
{
    public class InventoryController
    {
        private readonly OptimizedList<UserItem> _userItems = new OptimizedList<UserItem>();

        public void AddUserItem(int type, int count)
        {
            for (int index = 0; index < _userItems.Count; index++)
            {
                UserItem userItem = _userItems[index];

                if (userItem.type == type)
                {
                    userItem.count += count;
                    return;
                }
            }

            _userItems.Add(new UserItem(type, count));
        }

        public OptimizedList<UserItem> GetUserItems()
        {
            return _userItems;
        }
    }
}