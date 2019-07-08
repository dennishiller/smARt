using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class VirtualButtonHandeling : MonoBehaviour, IVirtualButtonEventHandler
{

    public UnityEngine.Video.VideoPlayer VideoPlayer;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (VideoPlayer.isPlaying)
        {
            VideoPlayer.Pause();
            text.text = "PAUSE";
            Debug.Log("isPlaying");
        } else if(VideoPlayer.isPaused)
        {
            VideoPlayer.Play();
            text.text = "PLAY";
            Debug.Log("isPausing");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }
}
