using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vuforia;

public class VideoManager : MonoBehaviour
{
    public Button btn;
    public Button playInARBtn;

    public TextMesh virtualBtntext;

    public UnityEngine.Video.VideoPlayer videoPlayerAR;

    public GameObject videoImageTarget;



    public UnityEngine.Video.VideoPlayer videoPlayerScreen;

    private double currentTime;


    // Start is called before the first frame update
    void Start()
    {
        playInARBtn.onClick.AddListener(onARClick);
        btn.onClick.AddListener(OnClick);
    }

    void onARClick()
    {
        Debug.Log("onARClick");

        currentTime = videoPlayerScreen.time;

        videoPlayerAR.time = currentTime;

        videoPlayerScreen.gameObject.SetActive(false);
        playInARBtn.gameObject.SetActive(false);

        videoPlayerAR.gameObject.SetActive(true);
        btn.gameObject.SetActive(true);

        videoPlayerAR.Play();

        if (videoPlayerAR.isPlaying)
        {
            btn.gameObject.SetActive(true);
        }

        if (videoImageTarget.GetComponent<TrackableBehaviour>().CurrentStatus != TrackableBehaviour.Status.TRACKED)
        {
            btn.gameObject.SetActive(false);
           
        }
    }

    void OnClick()
    {
        
        if (videoPlayerAR.isPlaying && !videoPlayerScreen.gameObject.activeSelf)
        {
            Debug.Log("videoPlayerAR.isPlaying && !screenVideo.activeSelf");
            currentTime = videoPlayerAR.time;
            videoPlayerAR.Pause();

            videoPlayerScreen.time = currentTime;
            
            btn.gameObject.SetActive(false);

            videoPlayerScreen.gameObject.SetActive(true);
            playInARBtn.gameObject.SetActive(true);


            videoPlayerAR.gameObject.SetActive(false);


            videoPlayerScreen.Play();

            virtualBtntext.text = "PLAY";
        }
        

        if (!videoPlayerAR.isPlaying && !videoPlayerScreen.gameObject.activeSelf)
        {
            Debug.Log("!videoPlayerAR.isPlaying && !screenVideo.activeSelf");

            currentTime = videoPlayerAR.time;

            videoPlayerScreen.time = currentTime;
            
            btn.gameObject.SetActive(false);

            videoPlayerScreen.gameObject.gameObject.SetActive(true);
            playInARBtn.gameObject.SetActive(true);

            videoPlayerAR.gameObject.SetActive(false);

            videoPlayerScreen.Play();

            virtualBtntext.text = "PAUSE";
        }
    }
}