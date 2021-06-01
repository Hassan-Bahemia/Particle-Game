using UnityEngine;

namespace Player
{
    public class PlayerName : MonoBehaviour
    {
        [SerializeField] private string _playerName;

        public string GetName()
        {
            return _playerName;
        }

        public void SetName(string NewPlayerName)
        {
            _playerName = NewPlayerName;
        }
    }
}
