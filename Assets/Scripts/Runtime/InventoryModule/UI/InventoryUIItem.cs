using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Runtime.InventoryModule.UI
{
    public class InventoryUIItem : UIBehaviour
    {
        [SerializeField]
        private Image _itemImage;

        [SerializeField]
        private TextMeshProUGUI _countText;

        private string _imageKey;
        private int _count;
        
        [Inject]
        public void Construct(string imageKey, int count)
        {
            _imageKey = imageKey;
            _count = count;
            
            UpdateView().Forget();
        }

        private async UniTaskVoid UpdateView()
        {
            _countText.text = _count.ToString();

            Sprite sprite = await AssetLibrary.LoadAndGetAssetAsync<Sprite>(_imageKey);
            _itemImage.sprite = sprite;
        }
        
        public class Factory : PlaceholderFactory<string, int, Transform, UniTask<InventoryUIItem>> { }
    }
}