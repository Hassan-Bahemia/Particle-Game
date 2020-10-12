using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerTrajectory : MonoBehaviour
{
    private LineRenderer _playerLR;

    [SerializeField] private float _zOffset = 15;

    private void Awake()
    {
        _playerLR = GetComponent<LineRenderer>();
    }

    
    public void RenderLine(Vector3 endPoint)
    {
        var startPoint = transform.position;
        startPoint.z = 0;

        endPoint = startPoint - endPoint;
        startPoint.z = _zOffset;
        endPoint.z = _zOffset;
        
        _playerLR.positionCount = 2;
        Vector3[] points = {startPoint, endPoint};

        _playerLR.SetPositions(points);
    }

    public void EndLine()
    {
        _playerLR.positionCount = 0;
    }
}
