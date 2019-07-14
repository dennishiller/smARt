using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vuforia;

/**
 * @class VideoManager
 *
 * @brief controls AR-video and Screen-Video with all their buttons, manages switching between AR-Mode and Screen-Mode
 * (playing the video on screen) 
 */
public class VideoManager : MonoBehaviour
{
    /// <summary>
    /// Screen-Button: "Play on Screen"
    /// </summary>
    [FormerlySerializedAs("btn")] public Button screenBtn;
    public Button playInARBtn;
    /// <summary>
    /// Virtual-Button-Text ("PLAY" / "PAUSE")
    /// </summary>
    public TextMesh virtualBtntext;
    /// <summary>
    /// AR - Video
    /// </summary>
    public UnityEngine.Video.VideoPlayer videoPlayerAR;
    /// <summary>
    /// Screen - Video
    /// </summary>
    public UnityEngine.Video.VideoPlayer videoPlayerScreen;
    /// <summary>
    /// 
    /// </summary>
    public GameObject videoImageTarget;
    /// <summary>
    /// current time which will be passed on to the other AR-video/Screen-Video, so the other video continues
    /// from that time
    /// </summary>
    private double currentTime;


    // Start is called before the first frame update
    public void Start()
    {
        playInARBtn.onClick.AddListener(onARClick);
        screenBtn.onClick.AddListener(OnClick);
    }

    /**
     * @brief event handler for playInAR-Button: change from Screen- Mode to AR-Mode (from screen video to AR-video)
     *
     * Since playInAR-Button will only show if Screen-Video plays, we can be sure that we will always get the
     * current time from the screen video, which we will save in currentTime to tell AR - video to start from
     * that time.
     * Before start on playing AR video, we disable our screen video - gameobject and playInAR-Button, and therefore
     * enable AR-video and screen-Button.
     *
     * We have to check if the AR-video image target is still tracked, which is why we have two cases:
     * case 1 - yes: AR-video plays regularly, enable Screen-Button, Virtual-Buttontext will set to "PAUSE";
     * case 2 - no: AR-video stops playing, disable Screen-Button
     */
    public void onARClick()
    {
        

        currentTime = videoPlayerScreen.time;

        videoPlayerAR.time = currentTime;

        videoPlayerScreen.gameObject.SetActive(false);
        playInARBtn.gameObject.SetActive(false);

        videoPlayerAR.gameObject.SetActive(true);
        screenBtn.gameObject.SetActive(true);
        
        

        videoPlayerAR.Play();

        if (videoPlayerAR.isPlaying)
        {
            screenBtn.gameObject.SetActive(true);
            virtualBtntext.text = "PAUSE";
        }

        if (videoImageTarget.GetComponent<TrackableBehaviour>().CurrentStatus != TrackableBehaviour.Status.TRACKED)
        {
            screenBtn.gameObject.SetActive(false);
            videoPlayerAR.Pause();
            
           
        }
    }

    
    /**
     * @brief event handler for screen-Button: change from AR-Mode to Screen-Mode (from AR-video to screen-video)
     *
     * Since the screen-Button will only show if AR-video image target is tracked, we have 2 cases:
     * case 1 - AR-video is playing: current time of AR-video will be passed to screen-video, AR-video will pause, 
     * screen-Button will be disabled, screen-Video starts playing;
     * case 2 - AR is not playing (user can control AR-video with Virtual-Button): current time of AR-video will be
     * passed to screen-video, screen-Button will be disabled, screen-Video starts playing
     */
    public void OnClick()
    {
        
        if (videoPlayerAR.isPlaying && !videoPlayerScreen.gameObject.activeSelf)
        {
            
            currentTime = videoPlayerAR.time;
            videoPlayerAR.Pause();

            videoPlayerScreen.time = currentTime;
            
            screenBtn.gameObject.SetActive(false);

            videoPlayerScreen.gameObject.SetActive(true);
            playInARBtn.gameObject.SetActive(true);


            videoPlayerAR.gameObject.SetActive(false);


            videoPlayerScreen.Play();

            virtualBtntext.text = "PLAY";
        }
        

        if (!videoPlayerAR.isPlaying && !videoPlayerScreen.gameObject.activeSelf)
        {
            

            currentTime = videoPlayerAR.time;

            videoPlayerScreen.time = currentTime;
            
            screenBtn.gameObject.SetActive(false);

            videoPlayerScreen.gameObject.gameObject.SetActive(true);
            playInARBtn.gameObject.SetActive(true);

            videoPlayerAR.gameObject.SetActive(false);

            videoPlayerScreen.Play();

            virtualBtntext.text = "PLAY";
        }
    }
}