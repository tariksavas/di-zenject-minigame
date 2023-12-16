namespace Runtime.InventoryModule.Model
{
    public struct UserItem
    {
        public int type;
        public int count;

        public UserItem(int type, int count)
        {
            this.type = type;
            this.count = count;
        }
    }
}