using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MenüScript : MonoBehaviour
{
    bool cameraOn = false;
    bool pause = false;
    public GameObject start_button;
    public GameObject back_button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VuforiaBehaviour.Instance.enabled = cameraOn;
        pauseAnimation();
    }

    public void turnOnVuforia()
    {
        //if (cameraOn == false)
        //{
            cameraOn = true;
        //Debug.Log("IST AN");
        //}
        //else if(cameraOn == true)
        //{
        //    cameraOn = false;
        //    //Debug.Log("IST AUS");
        //}

        start_button.SetActive(false);
        back_button.SetActive(true);
    }

    public void backToMenu()
    {
        cameraOn = false;
        start_button.SetActive(true);
        back_button.SetActive(false);
    }

    public void pauseButton()
    {
        if (pause == false)
        {
            pause = true;
        }
        else if (pause == true)
        {
            pause = false;
        }

    }

    void pauseAnimation()
    {
        if (pause == false)
        { 
            Time.timeScale = 1;
        }
        else if(pause == true)
        {
            Time.timeScale = 0;
        }
    }
}
