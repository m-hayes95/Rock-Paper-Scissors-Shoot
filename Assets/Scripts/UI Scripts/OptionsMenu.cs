using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer audioMixer;

    private const string MASTER_VOLUME = "MasterVolume";

    public void SetCurrentVolume(float masterVolumeSlider)
    {
        // Debug.Log(masterVolumeSlider);
        // Set audio mixer master volume value to the current slider value.
        audioMixer.SetFloat(MASTER_VOLUME, masterVolumeSlider);
    }
}
