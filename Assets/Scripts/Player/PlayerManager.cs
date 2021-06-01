using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _players;
        [SerializeField] private string[] _playerID;
        [SerializeField] private Gradient[] _playerColours;
        [SerializeField] public int playerID;
        [SerializeField] public string newPlayerID;
        [SerializeField] public int playerColourIndex;
        [SerializeField] public Gradient playerColour;

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
            playerID = _players.Count % _playerID.Length;
            newPlayerID = _playerID[playerID];
            playerColourIndex = _players.Count % _playerColours.Length;
            playerColour = _playerColours[playerColourIndex];
            newPlayer.GetComponent<PlayerColour>().SetColour(playerColour);
            newPlayer.GetComponent<PlayerName>().SetName(newPlayerID);

            _players.Add(newPlayer);
        }
    }
}