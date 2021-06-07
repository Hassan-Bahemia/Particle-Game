using UnityEngine;

namespace Player
{
    public class PlayerName : MonoBehaviour
    {
        [SerializeField] private string _playerName;
        [SerializeField] private GameObject _playerText;

        public string GetName()
        {
            return _playerName;
        }

        public GameObject GetText()
        {
            return _playerText;
        }
        

        public void SetName(string NewPlayerName, GameObject NewPlayerText)
        {
            _playerName = NewPlayerName;
            _playerText = NewPlayerText;
        }
    }
}
