using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;


public class MenüScript : MonoBehaviour
{
    bool cameraOn = true;
    bool pause = false;
    public GameObject pause_button;
    public GameObject SchmetterlingQuizTarget;
    public GameObject StatueQuizTarget;
    public GameObject ButterflyTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //VuforiaBehaviour.Instance.enabled = cameraOn;
        pauseAnimation();
        ChangeToSchmetterlingQuiz();
        ChangeToStatueQuiz();
        showPauseButton();
    }

    public void backToMenu()
    {
        //cameraOn = false;
        SceneManager.LoadScene("MainMenu");
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

    private void showPauseButton()
    {
        var trackable = ButterflyTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        if (status == TrackableBehaviour.Status.TRACKED)
        {
            pause_button.SetActive(true);
        }
        else
            pause_button.SetActive(false);

    }

    private void ChangeToSchmetterlingQuiz()
    {
            var trackable = SchmetterlingQuizTarget.GetComponent<TrackableBehaviour>();
            var status = trackable.CurrentStatus;
        
        //Debug.Log(status);
        if (status == TrackableBehaviour.Status.TRACKED)
            {
                SceneManager.LoadScene("SchmetterlingQuizScene");
            }
    }

    private void ChangeToStatueQuiz()
    {
        var trackable = StatueQuizTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;

        if (status == TrackableBehaviour.Status.TRACKED)
        {
            SceneManager.LoadScene("StatueQuizScene");
        }
    }
}
