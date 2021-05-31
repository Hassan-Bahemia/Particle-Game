using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    [SerializeField] private GameObject _captureZone;
    [SerializeField] private Gradient _captureGradient;

    // Start is called before the first frame update
    void Start()
    {
        _captureZone = GameObject.FindGameObjectWithTag("CaptureZone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
