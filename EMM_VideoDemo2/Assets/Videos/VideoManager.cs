using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{

    public Button btn;
    public UnityEngine.Video.VideoPlayer videoPlayerAR;
    public Text text;

    public RawImage image;
    public UnityEngine.Video.VideoPlayer videoPlayerScreen;


    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
        videoPlayerScreen = image.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayerAR.isPlaying)
        {
            image.gameObject.SetActive(false);
        }
    }

    void OnClick()
    {
        if (videoPlayerAR.isPlaying)
        {
            videoPlayerAR.Pause();
            image.gameObject.SetActive(true);
            videoPlayerScreen.Play();
            text.text = "Play In AR";
        }
        else
        {
            image.gameObject.SetActive(false);
            videoPlayerScreen.Pause();
            videoPlayerAR.Play();
            text.text = "Play On Screen";
            
        }



    }
}
