using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * @class Music Manager
 * 
 * @brief This script manages audio across all scenes
 * 
 * This script is saved in a prefab game object which is used to play the given 
 * audio across all scenes with the set volume. So whenever a scene is switch it 
 * plays from the beginning and the set volume from the options menu will not be 
 * deleted but saved.
 */
public class MusicMManager : MonoBehaviour
{
    /// <summary>
    /// Audiosource object refering to audio clip
    /// </summary>
    public AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        music.volume = PlayerPrefs.GetFloat("VolumeSlider");
    }
}
