using Cysharp.Threading.Tasks;
using Runtime.ConfigurationModule.Config;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
using UnityEngine;
using Zenject;

namespace Runtime.CollectibleModule
{
    public class CollectibleItem : MonoBehaviour
    {
        [Inject] 
        private readonly SignalController _signalController;
        
        private int _type;
        private int _value;
        
        [Inject]
        public void Construct(int type, int value)
        {
            _type = type;
            _value = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagConfig.PLAYER_TAG))
            {
                _signalController.Fire(new ItemValueChangedSignal(_type, _value));
                
                Destroy(gameObject);
            }
        }

        public class Factory : PlaceholderFactory<string, int, int, Vector3, UniTask<CollectibleItem>> { }
    }
}