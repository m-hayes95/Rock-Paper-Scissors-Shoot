using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//"How to do Camera Shake with Cinemachine!" by CodeMonkey
//https://www.youtube.com/watch?v=ACf1I27I6Tk
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    public static bool IsCameraShakeEnabled = true; // Ref on Options Menu.
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Don't allow 2 singletons.
        }

        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float shakeIntensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        // Set the amplitude gain to the intensity value
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        shakeTimer = time;
    }

    private void Update()
    {
        Debug.Log("Camera shake is " + IsCameraShakeEnabled);
        // Turn camera shake off after timer.
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }

    }
}
