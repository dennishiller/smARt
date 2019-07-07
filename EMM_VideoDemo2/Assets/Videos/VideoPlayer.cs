using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlayer : MonoBehaviour
{

    public UnityEngine.Video.VideoPlayer ARvideo;

    public GameObject video;

    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClick()
    {
        if (ARvideo.isPlaying && !video.active)
        {
            ARvideo.Pause();
            video.SetActive(true);
            text.text = "Play in AR";
        }
        else
        {
            ARvideo.Play();
            video.SetActive(false);
            text.text = "Play on Screen";
        }
    }
}
