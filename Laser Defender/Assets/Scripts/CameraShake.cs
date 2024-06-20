using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1.0f;
    [SerializeField] private float shakeMagnitude = 0.5f;


    private Camera mainCamera;
    private Vector3 initialCameraPosition;
    void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }
    private IEnumerator ShakeCameraCoroutine()
    {
        float timer = 0f;

        while(shakeDuration > timer)
        {
            transform.position = initialCameraPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
 
        transform.position = initialCameraPosition;
        
    }

}
