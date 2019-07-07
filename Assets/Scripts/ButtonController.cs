using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ReturnButton;
    
    public void CameraScene()
    {
        SceneManager.LoadScene("All-Scenes");
    }
}
