using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

/**
 * @class MenüScript
 * 
 * @brief is managing some Vuforia features. Calls the quiz and the butterfly model which is pausible.
 */
public class MenüScript : MonoBehaviour
{
    /// <summary>
    /// boolean to check if pause-button was pressed. if true, butterfly animation is paused
    /// </summary>   
    bool pause = false;

    /// <summary>
    /// Pause button
    /// </summary>   
    public GameObject pause_button;

    /// <summary>
    /// butterfly quiz target
    /// </summary>  
    public GameObject SchmetterlingQuizTarget;

    /// <summary>
    /// statue quiz target
    /// </summary>  
    public GameObject StatueQuizTarget;

    /// <summary>
    /// butterfly model target
    /// </summary>  
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


    /**
     * @brief if pause button is pressed, it changes boolean pause to true/false. 
     * 
     * case 1 - if pause = false -> pause = true
     * case 2 - if pause = true -> pause = false
     */
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

    /**
     * @brief butterfly animation is paused when pause is true, and is playing again if pause is false.
     * 
     * case 1 - if animation is playing, pause it.
     * case 2 - if animation is paused, play it.
     */
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

    /**
     * @brief checks if butterfly target is tracked. if its tracked the pause-button will appear. Else the button will be hidden.
     *
     * case 1 - if its tracked, show button
     * case 2 - if its untracked, hide button
     */
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

    /**
     * @brief if butterly quiz target is tracked, a scene change will happen, which shows the quiz.
     */
    private void ChangeToSchmetterlingQuiz()
    {
            var trackable = SchmetterlingQuizTarget.GetComponent<TrackableBehaviour>();
            var status = trackable.CurrentStatus;
        
        Debug.Log("schmetterling");
        if (status == TrackableBehaviour.Status.TRACKED)
            {
                SceneManager.LoadScene(4);
            }
    }

    /**
    * @brief if statue quiz target is tracked, a scene change will happen, which shows the quiz.
    */
    private void ChangeToStatueQuiz()
    {
        var trackable = StatueQuizTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;

        if (status == TrackableBehaviour.Status.TRACKED)
        {
            SceneManager.LoadScene(3);
        }
    }
}