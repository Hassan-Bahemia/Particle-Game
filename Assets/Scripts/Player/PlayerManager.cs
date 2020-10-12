using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _players;
        [SerializeField] private Gradient[] _playerColours;

        public int GetPlayerCount()
        {
            return _players.Count;
        }

        public List<GameObject> GetPlayers()
        {
            return _players;
        }

        public void AddPlayer(GameObject newPlayer)
        {
            var playerColourIndex = _players.Count % _playerColours.Length;
            var playerColour = _playerColours[playerColourIndex];
            newPlayer.GetComponent<PlayerColour>().SetColour(playerColour);
            
            _players.Add(newPlayer);
        }
    }
}