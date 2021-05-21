using System;
using System.Collections.Generic;
using Input_Support;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        private readonly List<InputDevice> _devices = new List<InputDevice>();
        [SerializeField] private int _maxPlayers;
        [SerializeField] private int _playerCount;
        [SerializeField] private float _spawnXBound;
        [SerializeField] private List<Key> _keysToIgnore;
        [SerializeField] private GameObject _MousePlayer;
        [SerializeField] private GameObject _ControllerPlayer;
        private PlayerManager _playerManager;
        private MouseInput _mouseInput;

        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
        }


        private void Update()
        {
            if (_playerCount >= _maxPlayers)
                return;
            UpdateController();
            UpdateMouse();
        }

        private void UpdateController()
        {
            foreach (var gamepad in Gamepad.all)
            {
                if (_devices.Contains(gamepad))
                    continue;
                if (!gamepad.buttonSouth.wasPressedThisFrame)
                    continue;
                //Spawns New Gamepad Player
                _devices.Add(gamepad);
                var player = SpawnPlayer(_ControllerPlayer);
                player.GetComponent<ControllerInput>().SetGamepad(gamepad);
                _playerCount++;
                print(_devices.Count);
            }
        }

        private void UpdateMouse()
        {
            if (_devices.Contains(Mouse.current)) 
                return;
            if (!Mouse.current.leftButton.isPressed)
                return; 
            _devices.Add(Mouse.current);
            var player = SpawnPlayer(_MousePlayer);
            _mouseInput = player.GetComponent<MouseInput>();
            _playerCount++;
        }
        
        private void IgnoreKey(Key keyToIgnore)
        {
            if (!_keysToIgnore.Contains(keyToIgnore))
                _keysToIgnore.Add(keyToIgnore);
        }

        private GameObject SpawnPlayer(GameObject playerPrefab)
        {
            var randomX = Random.Range(-_spawnXBound, _spawnXBound);
            var t = transform;
            var spawnPos = new Vector2(randomX, t. position.y);
            var newPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity, t);
            _playerManager.AddPlayer(newPlayer);
            return newPlayer;
        }
    }
}