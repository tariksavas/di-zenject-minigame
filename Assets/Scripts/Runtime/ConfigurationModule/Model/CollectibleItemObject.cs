using UnityEngine;

namespace Runtime.ConfigurationModule.Model
{
    [CreateAssetMenu(fileName = "New CollectibleItem", menuName = "CollectibleItem")]
    public class CollectibleItemObject : LoadableScriptableObject
    {
        public int minCount;
        public int maxCount;

        public int minValue;
        public int maxValue;

        public string assetKey;
    }
}