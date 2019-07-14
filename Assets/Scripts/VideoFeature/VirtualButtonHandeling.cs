using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/**
 * @class VirtualButtonHandeling
 *
 * @brief handles Virtual-Button for playing AR-Video (Play,Pause)
 */
public class VirtualButtonHandeling : MonoBehaviour, IVirtualButtonEventHandler
{
    /// <summary>
    /// AR-Video(-player)
    /// </summary>
    public UnityEngine.Video.VideoPlayer VideoPlayer;
    /// <summary>
    /// Virtual Button Text
    /// </summary>
    public TextMesh text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }

    }
    

    /**
     * @brief event handler for Virtual-Button
     *
     * 2 different cases for Virtual Button when it is pressed:
     * case 1 - AR-video is playing: AR-video will pause, Virtual-Buttontext set to "PLAY";
     * case 2 - AR-video is pausing: AR-Video will play, Virtual-Buttontext set to "PAUSE"
     *
     * @param vb virtual button
     *
     */
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (VideoPlayer.isPlaying)
        {
            
            VideoPlayer.Pause();
            text.text = "PLAY";
            
        } else if(VideoPlayer.isPaused)
        {
            VideoPlayer.Play();
            text.text = "PAUSE";
            
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
       
    }
}
