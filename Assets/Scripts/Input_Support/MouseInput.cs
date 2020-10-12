using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input_Support
{
    public class MouseInput : Base_Input
    {
        private Vector2 _startPoint;
        private Vector2 _endPoint;

        private Vector2 _mouseDelta;

        protected override void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                OnButtonDown();
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                OnButtonUp();
            }
            _mouseDelta = Mouse.current.position.ReadValue();
            base.Update();
        }

        protected override void RenderLine()
        {
            var force = _startPoint - _mouseDelta ;
            _playerTrajectory.RenderLine(NormalizeForce(force));
        }

        protected override void OnButtonDown()
        {
            _startPoint = _mouseDelta;
            base.OnButtonDown();
        }

        protected override void OnButtonUp()
        {
            _endPoint = _mouseDelta;
            var force = _startPoint - _endPoint;
            _playerMovement.Move(NormalizeForce(force));
            base.OnButtonUp();
        }
    }
}