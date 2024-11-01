using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1.0f;
    [SerializeField] private float shakeMagnitude = 0.5f;
    private Camera mainCamera;
    private Vector3 initialCameraPosition;
    private void OnEnable()
    {
        Health.OnPlayerDamaged += HandlePlayerDamage;
    }
    private void OnDisable()
    {
        Health.OnPlayerDamaged -= HandlePlayerDamage;
    }

    private void HandlePlayerDamage()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
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
