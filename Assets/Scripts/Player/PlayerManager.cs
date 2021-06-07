using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _players;
        //Text
        [SerializeField] private GameObject[] _playerTextPrefab;
        [SerializeField] private int playerTextPrefabIndex;
        [SerializeField] private GameObject playerText;
        //ID
        [SerializeField] private string[] _playerID;
        [SerializeField] public int playerID;
        [SerializeField] public string newPlayerID;
        //Color
        [SerializeField] private Gradient[] _playerColours;
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
            playerTextPrefabIndex = _players.Count % _playerTextPrefab.Length;
            playerText = _playerTextPrefab[playerTextPrefabIndex];
            playerColourIndex = _players.Count % _playerColours.Length;
            playerColour = _playerColours[playerColourIndex];
            newPlayer.GetComponent<PlayerColour>().SetColour(playerColour);
            newPlayer.GetComponent<PlayerName>().SetName(newPlayerID, playerText);

            _players.Add(newPlayer);
        }
    }
}