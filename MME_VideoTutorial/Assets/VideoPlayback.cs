using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayback : MonoBehaviour
{

    public VideoPlaybackBehavior video;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnClick() //your button click
    {
        video.VideoPlayer.Play(true, 0); //true makes it fullscreen
    }
}
