using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScanlineEffect : MonoBehaviour
{
    [SerializeField] private Material material;
    
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetTexture("_MainTex", source);
        Graphics.Blit(source, destination, material);
    }
}

