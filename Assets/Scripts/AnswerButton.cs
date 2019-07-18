using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * @class AnswerButton
 *
 * @brief AnswerButton Objects are generated of that Class
 */
public class AnswerButton : MonoBehaviour
{
    /// <summary>
    /// AnswerText
    /// </summary>
    public Text answerText;
    /// <summary>
    /// AnswerData - carries Answerdata
    /// </summary>
    private AnswerData answerData;
    /// <summary>
    /// GameController
    /// </summary>
    private GameController gameController;


    /**
* @brief searching for GameController on init
*/
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    /**
   * @brief initialisation of class
   *
   * labeling the button and giving answerData attributes
   */
    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    /**
   * @brief event handler for clicking a button
   *
   * Handles a Click Event on this button. Returns true if the choice is correct, returns false if the choice is incorrect 
   */
    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}