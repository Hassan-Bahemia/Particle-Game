using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input_Support;
using UnityEditor;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        isPaused = false;
        _HUD.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateControllerPause();
        UpdateKeyboardPause();
    }

    private void UpdateControllerPause()
    {
        foreach (var gamepad in Gamepad.all)
        {
            if (!gamepad.buttonEast.wasReleasedThisFrame)
                continue;
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }

        }
    }

    private void UpdateKeyboardPause()
    {
        if (!Keyboard.current.escapeKey.wasReleasedThisFrame)
            return;
        if (!isPaused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }
    

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        _HUD.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    private void UnPause()
    {
        Time.timeScale = 1f;
        isPaused = false;
        _HUD.SetActive(true);
        _pauseMenu.SetActive(false);
    }
}
