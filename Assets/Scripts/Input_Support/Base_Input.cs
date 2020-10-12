using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Base_Input : MonoBehaviour
{
     
     [SerializeField] protected float _minForce;
     [SerializeField] protected float _maxForce;
     [SerializeField] protected float _forceMultiplier;

     protected PlayerTrajectory _playerTrajectory;

     protected PlayerMovement _playerMovement;
     protected bool _isDown;

     protected virtual void Awake()
     {
          _playerMovement = GetComponent<PlayerMovement>();
          _playerTrajectory = GetComponent<PlayerTrajectory>();
     }

     protected virtual void RenderLine()
     {
          return;
     }
     
     protected virtual void Update()
     {
          if (_isDown && _playerMovement.CanMove())
          {
               RenderLine();
          }
          else
          {
               _playerTrajectory.EndLine();
          }
     }

     protected Vector2 NormalizeForce(Vector2 force)
     {
          var nForce = force.normalized;
          var mForce = Mathf.Clamp(force.magnitude * _forceMultiplier, _minForce, _maxForce);
          var moveForce = nForce * mForce;
          return moveForce;
     }

     protected virtual void OnButtonDown()
     {
          _isDown = true;
     }

     protected virtual void OnButtonUp()
     {
          _isDown = false;
     }
}
