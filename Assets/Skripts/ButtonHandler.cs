using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ButtonHandler : MonoBehaviour
{

    public Button PlayOnScreenBtn;

    public GameObject video;
    public UnityEngine.Video.VideoPlayer aRVideo;

    public VirtualButton virtualButton;

    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayOnScreenBtn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        
        if (!video.active)
        {
            text.text = "Play in AR";
            aRVideo.Pause();
            video.SetActive(true);
            virtualButton.SetEnabled(false);
        }
        else
        {
            text.text = "Play on Screen";
            aRVideo.Play();
            video.SetActive(false);
            virtualButton.SetEnabled(true);
        }
        
    }
}
