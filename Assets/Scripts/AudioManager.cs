using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 *@class Audio Manager
 * 
 * @brief Manages the audio's volume
 * 
 * Script for an empty game object "volume controller", which connects audio source 
 * with the volume slider. Also used to avoid repetitive usage of code, e.g. in canvas
 * for sound menu.
 * 
 */

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Audiosource object refering to audio clip
    /// </summary>
    public AudioSource music;
    /// <summary>
    /// Slider object refering to volume slider in options menu
    /// </summary>
    public Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("VolumeSlider");
    }
    /*
     *@brief Updating current music volume to set slider volume 
     */
    private void Update()
    {
        music.volume = volume.value;
    }
    /*
     * @brief Method for saving players slider input
     */
    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("VolumeSlider", music.volume);
    }
}
