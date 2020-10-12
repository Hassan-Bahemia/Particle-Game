using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input_Support
{
    public class ControllerInput : Base_Input
    {
        [SerializeField, Range(0, 1)] private float _speed = 0.1f;
        private float _currentMag;
        private Vector2 _currentNForce;

        private Gamepad _controller;

        public void SetGamepad(Gamepad gamepad)
        {
            _controller = gamepad;
        }

        protected override void Update()
        {
            if (_controller.rightTrigger.wasReleasedThisFrame)
            {
                OnButtonUp();
            }
            else if (_controller.rightTrigger.wasPressedThisFrame)
            {
                OnButtonDown();
            }
            var leftStick = _controller.leftStick.ReadValue();
            _currentMag = Mathf.Lerp(_currentMag, -leftStick.magnitude, _speed);
            _currentNForce = leftStick.normalized * _currentMag;
            base.Update();
        }

        protected override void RenderLine()
        {
            _playerTrajectory.RenderLine(NormalizeForce(_currentNForce));
        }
        
        protected override void OnButtonUp()
        {
            _playerMovement.Move(NormalizeForce(_currentNForce));
            base.OnButtonUp();
        }
    }
}