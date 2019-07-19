using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

/**
 * @class QuizManager
 *
 * @brief controls when the guiz gui is shown 
 */
public class QuizManager : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
	
    private bool mShowQuiz = false;
    public GameObject gameCanvas; 
	
    
    /**
* @brief initialisation of class
*
* registering datahandler
*/
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
    /**
 * @brief activates the gui when tracker is detected or tracked 
 */
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            gameCanvas.SetActive(true);
        }
        else
        {
            gameCanvas.SetActive(false);
        }
    }
}
