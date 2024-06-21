using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScrollBackground : MonoBehaviour
{
    [SerializeField] private Material backgroundMaterial = null;
    [SerializeField] private Vector2 speed;

    private Vector2 offset;

    private void Start()
    {
        backgroundMaterial.mainTextureOffset = Vector2.zero;
    }

    void Update()
    {
        offset = speed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
        
    }
}
