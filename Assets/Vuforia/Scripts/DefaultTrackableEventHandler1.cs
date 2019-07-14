/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
/**
 * @class DefaultTrackableEventHandler1
 *
 * @brief event tracking handler only for video-feature
 *
 * Since we have different image targets to track and video-feature has a specific behaviour when it is tracked,
 * we created an extra tracking event handler script.
 * It is a given script from Vuforia with small extended functions for the video-feature. 
 */
public class DefaultTrackableEventHandler1 : MonoBehaviour, ITrackableEventHandler
{
    /// <summary>
    /// Screen-Button "Play On Screen"
    /// </summary>
    [FormerlySerializedAs("ARBtn")] public GameObject playOnScreenBtn;
    /// <summary>
    /// AR-Video
    /// </summary>
    [FormerlySerializedAs("video")] public VideoPlayer aRVideo;
    /// <summary>
    /// Screen-Video
    /// </summary>
    public VideoPlayer screenVideo;
    /// <summary>
    /// Virtual-Button-Text ("PLAY" / "PAUSE")
    /// </summary>
    public TextMesh virtualBtn;
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        //playOn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    /**
     * @brief method describes what will happen when image target is tracked
     *
     * AR-video will start playing and Virtual-Buttontext will set "PAUSE", if screen-video is not playing.
     */
    protected virtual void OnTrackingFound()
    {
        if (!screenVideo.isPlaying)
        {
            playOnScreenBtn.SetActive(true);
            aRVideo.Play();
            virtualBtn.text = "PAUSE";
        }
        

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    /**
     * @brief method describes what will happen if tracking lost
     *
     * AR-video will pause, so if image target is tracked again, then it will continue playing from the same time
     * later on. PlayOnScreen-Button will be disabled.
     * 
     */
    protected virtual void OnTrackingLost()
    {
        
        aRVideo.Pause();
        virtualBtn.text = "PLAY";
        playOnScreenBtn.SetActive(false);

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS
}