using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @class Main Menu 
 * 
 * @brief Script for changing between scenes 
 * 
 * This script helps to change between the given scenes
 */
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Options button on main menu 
    /// </summary>
    public GameObject OptionsButton;
    /// <summary>
    /// Start Button to start app (actually just switching to camera scene)
    /// </summary>
    public GameObject StartMenu;
    /// <summary>
    /// Empty GameObject OptionsMenu to activate and deactivate options menu and main menu
    /// </summary>
    public GameObject MenuOptions;
    /// <summary>
    /// Return button to switch to previous scene or menu
    /// </summary>
    public GameObject ReturnButton;

    /*
    * @brief Switch to instructions scene 
    */
    public void InstrucitonsScene()
    {
        SceneManager.LoadScene("Instructions");
    }
    /*
    * @brief Method to return to main menu (mostly used by return button)
    */
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /*
     * @brief Switch to camera scene called all-scenes
     */
    public void CameraScene()
    {
        SceneManager.LoadScene("All-Scenes");
    }

    /*
     * @brief Quit application
     */
    public void Quit()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
