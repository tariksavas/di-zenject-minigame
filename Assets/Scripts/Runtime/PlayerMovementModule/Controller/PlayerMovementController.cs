using System;
using Cysharp.Threading.Tasks;
using Runtime.AssetManagement;
using Runtime.SignalBus.Controller;
using Runtime.SignalBus.Signal;
using UnityEngine;
using Zenject;

namespace Runtime.PlayerMovementModule.Controller
{
    public class PlayerMovementController : IInitializable, IDisposable
    {
        private readonly SignalController _signalController;
        
        private readonly DiContainer _diContainer;

        private const string PLAYER_KEY = "Player";
        private const float MOVEMENT_SPEED = 50f;

        private Rigidbody _playerRigidbody;
        
        public PlayerMovementController(SignalController signalController, DiContainer diContainer)
        {
            _signalController = signalController;
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            CreatePlayer().Forget();
        }

        private async UniTaskVoid CreatePlayer()
        {
            GameObject playerObject = await AssetLibrary.LoadAndGetAssetAsync<GameObject>(PLAYER_KEY);
            _playerRigidbody = _diContainer.InstantiatePrefabForComponent<Rigidbody>(playerObject);
            
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _signalController.Subscribe<PlayerMovementInputSignal>(OnPlayerMovementSignalFired);
        }

        private void OnPlayerMovementSignalFired(PlayerMovementInputSignal playerMovementInputSignal)
        {
            _playerRigidbody.MovePosition(_playerRigidbody.transform.position +
                                          playerMovementInputSignal.Axis * Time.deltaTime * MOVEMENT_SPEED);
        }
        
        private void UnsubscribeEvents()
        {
            _signalController.UnSubscribe<PlayerMovementInputSignal>(OnPlayerMovementSignalFired);
        }
        
        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}