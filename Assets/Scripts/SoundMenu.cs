using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Sound Menu
 * 
 *@brief Script in order to play sound in setted volume, which is also connected to volume slider
 * 
 */
public class SoundMenu : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("VolumeSlider");
    }
}
