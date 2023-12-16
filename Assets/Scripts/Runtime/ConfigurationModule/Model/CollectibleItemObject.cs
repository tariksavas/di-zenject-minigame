using UnityEngine;

namespace Runtime.ConfigurationModule.Model
{
    [CreateAssetMenu(fileName = "New CollectibleItem", menuName = "CollectibleItem")]
    public class CollectibleItemObject : LoadableScriptableObject
    {
        public int minCount = 0;
        public int maxCount = 10;

        public string assetKey;
    }
}