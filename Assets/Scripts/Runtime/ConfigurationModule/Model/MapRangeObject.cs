using UnityEngine;

namespace Runtime.ConfigurationModule.Model
{
    [CreateAssetMenu(fileName = "New MapRange", menuName = "MapRange")]
    public class MapRangeObject : LoadableScriptableObject
    {
        public float maxX;
        public float minX;
        public float maxZ;
        public float minZ;
        public float fixedY;
    }
}