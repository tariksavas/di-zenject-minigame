using Runtime.StructuralDefinitions;
using UnityEngine;

namespace Runtime.ConfigurationModule.Config
{
    public static class KeyCodeConfigs
    {
        public static OptimizedList<KeyCode>
            INVENTORY_OPEN_CLOSE_BUTTONS = new(new[] { KeyCode.I, KeyCode.C });
    }
}