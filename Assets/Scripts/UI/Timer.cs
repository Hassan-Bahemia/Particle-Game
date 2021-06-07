using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeSinceStart;
    [SerializeField] private bool _isTimerRunning;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _isTimerRunning = true;
    }

    private void Update()
    {
        var minutes = Mathf.FloorToInt(_timeSinceStart / 60);
        var seconds = Mathf.FloorToInt(_timeSinceStart % 60);
        if (_isTimerRunning)
        {
            if (_timeSinceStart > 0)
            {
                _timeSinceStart -= Time.deltaTime;
                _text.text = $"Time {minutes:00}:{seconds:00}"; 
            }
            else
            {
                _timeSinceStart = 0;
                _isTimerRunning = false;
            }
            if (_timeSinceStart < 60)
            {
                _text.text = $"Time {minutes:00}:{seconds:00}";
            }
        }
    }
}
