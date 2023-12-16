using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;
using Zenject;

namespace Runtime.UI
{
    public class UIPanel : UIBehaviour
    {
        public class Factory : PlaceholderFactory<string, UniTask<UIPanel>> {}
    }
}