using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _players;
        [SerializeField] private string[] _playerID;
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
            var playerID = _players.Count % _playerID.Length;
            var newPlayerID = _playerID[playerID];
            var playerColourIndex = _players.Count % _playerColours.Length;
            var playerColour = _playerColours[playerColourIndex];
            newPlayer.GetComponent<PlayerColour>().SetColour(playerColour);
            newPlayer.GetComponent<PlayerName>().SetName(newPlayerID);

            _players.Add(newPlayer);
        }
    }
}