using UnityEngine;

namespace Runtime.ConfigurationModule.Model
{
    [CreateAssetMenu(fileName = "New InventoryItem", menuName = "InventoryItem")]
    public class InventoryItemObject : LoadableScriptableObject
    {
        public string imageKey;
    }
}