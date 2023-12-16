using Runtime.ConfigurationModule.Model;
using UnityEngine;

namespace Runtime.ConfigurationModule.Controller
{
    public class ScriptableConfigurationController : IConfigurationController
    {
        private const string INVENTORY_ITEMS_PATH = "Config/Inventory/Item";
        private const string COLLECTIBLE_ITEMS_PATH = "Config/Collectible/Item";
        
        private InventoryItemObject[] _inventoryItemObjects;
        
        private CollectibleItemObject[] _collectibleItemObjects;
        
        public ScriptableConfigurationController()
        {
            _inventoryItemObjects = LoadItems<InventoryItemObject>(INVENTORY_ITEMS_PATH);
            _collectibleItemObjects = LoadItems<CollectibleItemObject>(COLLECTIBLE_ITEMS_PATH);
        }

        private T[] LoadItems<T>(string path) where T : LoadableScriptableObject
        {
            T[] loadedObjects = Resources.LoadAll<T>(path);

            T[] objects = new T[loadedObjects.Length];
            
            for (int index = 0; index < loadedObjects.Length; index++)
            {
                T loadedObject = loadedObjects[index];

                objects[loadedObject.type] = loadedObject;
            }

            return objects;
        }
        
        public T GetInventoryItemConfig<T>(int type) where T : class
        {
            return _inventoryItemObjects[type] as T;
        }

        public T GetCollectibleItemConfig<T>(int type) where T : class
        {
            return _collectibleItemObjects[type] as T;
        }

        public T[] GetCollectibleItemConfigs<T>() where T : class
        {
            return _collectibleItemObjects as T[];
        }
    }
}