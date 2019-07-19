using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @class Sound on Click
 * 
 * @brief SoundonClick allows to audio for Buttons 
 * 
 * This script enables a click sound whenever the button, this script is 
 * used on, is clicked. So first this script requires a component of a 
 * type button. 
 */
[RequireComponent(typeof(Button))]
public class SoundonClick : MonoBehaviour
{
    /// <summary>
    /// Audiosource object refering to audio clip
    /// </summary>
    public AudioClip sound;

    /*
     * @brief Gets a component of type button
     */
    private Button button { get { return GetComponent<Button>(); } }
    /*
     * @brief Gets a component of type audio source
     */
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    /*
     * @brief If a sound is added it will play on click and won't play on awake
     */
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }
    /*
     * 
     * @brief Plays click sound one time only when clicked 
     * 
     */
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
