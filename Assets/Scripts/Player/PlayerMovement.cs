using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _moveDelay = 1;
    private float _timeSinceMoved;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _timeSinceMoved += Time.deltaTime;
    }

    public bool CanMove()
    {
        return _timeSinceMoved >= _moveDelay;
    }
    

    public void Move(Vector2 inputAxis)
    {
        if (!CanMove()) 
            return;
        _timeSinceMoved = 0;

        _rb.AddForce(inputAxis * _speed, ForceMode2D.Impulse);
        print(inputAxis);
    }

}
