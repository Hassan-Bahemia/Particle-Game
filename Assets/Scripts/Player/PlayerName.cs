using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
