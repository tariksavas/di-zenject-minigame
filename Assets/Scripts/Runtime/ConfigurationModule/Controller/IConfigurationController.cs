namespace Runtime.ConfigurationModule.Controller
{
    public interface IConfigurationController
    {
        public T GetInventoryItemConfig<T>(int type) where T : class;
        
        public T GetCollectibleItemConfig<T>(int type) where T : class;
        
        public T[] GetCollectibleItemConfigs<T>() where T : class;
        
        public T GetMapRangeConfig<T>(int type) where T : class;
    }
}