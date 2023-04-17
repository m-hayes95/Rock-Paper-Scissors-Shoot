using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Code ref from Brackeys "SETTINGS MENU in Unity" (Youtube)
//https://www.youtube.com/watch?v=YOaYQrN1oYQ

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer audioMixer;
    [SerializeField]
    private TMPro.TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    private const string MASTER_VOLUME = "MasterVolume";

    private void Start()
    {
        // Set the current resolutions to the screen resolution.
        resolutions = Screen.resolutions;
        // Remove any drop down options currently in the resolutions drop down menu.
        resolutionDropdown.ClearOptions();

        // Create a new list of resolution options for the dropdown.
        List<string> options = new List<string>();

        // Create an int variable for the current resolution setting.
        int currentResolutionIndex = 0;

        // Loop through each element within the resolutions array.
        for (int i = 0;i < resolutions.Length; i++)
        {
            // Assign each element to a string using the resolutions width x height.
            string option = resolutions[i].width + " x " + resolutions[i].height;
            // Add the created string to the new options list.
            options.Add(option);

            // Check if the current element within the for loop is equal to our current resolution.
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                // If they are equal, set the current resolution index to the current resolution.
                currentResolutionIndex = i;
            }
        }
        // Add the new options list to the current resolution dropdown.
        resolutionDropdown.AddOptions(options);
        // Set the current resolution within the dropdown menu to the games current resolution.
        resolutionDropdown.value = currentResolutionIndex;
        // Refresh the dropdown value to update it on screen.
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex) // Update the resolution to the one choosen in the resolution dropdown.
    {
        // Assign the resolution to the index to the resolution array.
        Resolution resolution = resolutions[resolutionIndex];
        // Set the resolutions width and height and set fullscreen to the current fullscreen bool value, set in the SetFullscreen method.
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetCurrentVolume(float masterVolumeSlider) // Update the master volume to the slider in the options menu.
    {
        // Debug.Log(masterVolumeSlider);
        // Set audio mixer master volume value to the current slider value.
        audioMixer.SetFloat(MASTER_VOLUME, masterVolumeSlider);
    }

    public void SetQuality(int qualityIndex) // Set the games quality setting in the quality dropdown.
    {
        // Select the current quality settings level using an int variable.
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen) // Set the fullscreen bool to true or false from the options menu toggle.
    {
        // Set the fullscreen option to the is full screen bool variable.
        Screen.fullScreen = isFullscreen;
    }

    
}
