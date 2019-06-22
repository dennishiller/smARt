using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class QuizManager : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
	
    private bool mShowQuiz = false;
    public GameObject gameCanvas; 
	
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
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
	
    void OnGUI() {
        if (mShowQuiz)
        {
            

        }
    }
}
