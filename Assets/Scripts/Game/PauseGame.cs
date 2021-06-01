using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private bool isPaused;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject[] _disabledComponents;

        private void Awake()
        {
            isPaused = false;
            _pauseMenu.SetActive(false);
            foreach (var t in _disabledComponents)
            {
                t.SetActive(true);
            }
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
                if (!gamepad.startButton.wasReleasedThisFrame)
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
            _pauseMenu.SetActive(true);
            foreach (var t in _disabledComponents)
            {
                t.SetActive(false);
            }
        }

        private void UnPause()
        {
            Time.timeScale = 1f;
            isPaused = false;
            _pauseMenu.SetActive(false);
            foreach (var t in _disabledComponents)
            {
                t.SetActive(true);
            }
        }
    }
}
