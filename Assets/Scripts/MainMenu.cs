using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsButton;
    public GameObject StartMenu;
    public GameObject MenuOptions;
    public GameObject ReturnButton;

    public void InstrucitonsScene()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Start is called before the first frame update
    public void CameraScene()
    {
        SceneManager.LoadScene("All-Scenes");
    }

    // Update is called once per frame
    public void Quit()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }

    //Block Image 
    //www.google.com/search?client=firefox-b-d&biw=1600&bih=731&tbm=isch&sa=1&ei=VQkNXdyQJs7IaN20r8gN&q=karierter+block&oq=karierter+block&gs_l=img.3..0i30l7j0i24.26921.30221..30426...2.0..0.157.1795.3j12......0....1..gws-wiz-img.......35i39j0j0i67.f1VQZubNCM4#imgrc=N-xyyLyUUtiqaM:
}
