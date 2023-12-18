using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;
using Zenject;

namespace Runtime.UI
{
    public class UIPanel : UIBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            
            SubscribeEvents();
        }

        protected virtual void SubscribeEvents()
        {
            
        }
        
        public void TogglePanel(bool toggle)
        {
            gameObject.SetActive(toggle);
        }
        
        public void ShowAndHidePanel()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        protected virtual void UnsubscribeEvents()
        {
            
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            UnsubscribeEvents();
        }

        public class Factory : PlaceholderFactory<string, UniTask<UIPanel>> {}
    }
}