using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class MenüScript : MonoBehaviour
{
    bool cameraOn = false;
    bool pause = false;
    public GameObject start_button;
    public GameObject back_button;
    public GameObject QuizTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VuforiaBehaviour.Instance.enabled = cameraOn;
        pauseAnimation();
        ChangeToQuiz();
    }

    public void turnOnVuforia()
    {
        cameraOn = true;
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

    private void ChangeToQuiz()
    {
        
        //QuizTarget.GetComponent<TrackableBehaviour>().CurrentStatus;
        //if (Input.GetKey(KeyCode.Q))
        //{
            var trackable = QuizTarget.GetComponent<TrackableBehaviour>();
            var status = trackable.CurrentStatus;
            if(status == TrackableBehaviour.Status.TRACKED)
            {
                SceneManager.LoadScene(1);
            }
        //}
    }
}
