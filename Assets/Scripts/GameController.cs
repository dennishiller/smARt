using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Texttemplate for Question
    /// </summary>
    public Text questionDisplayText;
    /// <summary>
    /// Texttemplate for Score
    /// </summary>
    public Text scoreDisplayText;
    /// <summary>
    /// Objectpool to generate Answerbuttons
    /// </summary>
    public SimpleObjectPool answerButtonObjectPool;
    /// <summary>
    /// Gui element where Buttons are inserted
    /// </summary>
    public Transform answerButtonParent;
    /// <summary>
    /// Gui element where Questiontext is located
    /// </summary>
    public GameObject questionDisplay;
    /// <summary>
    /// Overlay where Endgame Display is located
    /// </summary>
    public GameObject roundEndDisplay;
    /// <summary>
    /// Banner to inform User if the Answer was correct
    /// </summary>
    public GameObject correctDisplay;
    /// <summary>
    /// Banner to inform User if the Answer was not correct
    /// </summary>
    public GameObject badDisplay;

    /// <summary>
    /// controls data
    /// </summary>
    private DataController dataController;
    /// <summary>
    /// holds information about current round data
    /// </summary>
    private RoundData currentRoundData;
    /// <summary>
    /// Pool of questions
    /// </summary>
    private QuestionData[] questionPool;
    
    /// <summary>
    /// runner variable
    /// </summary>
    private int questionIndex;
    /// <summary>
    /// score for round
    /// </summary>
    private int playerScore;
    /// <summary>
    /// All Answerbuttons
    /// </summary>
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    
    
    /**
     * @brief initialize current round
     *
     * resets display, load question into gui
     */
    void Start()
    {
        roundEndDisplay.SetActive(false);
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
    }

    
    /**
     * @brief shows actual question and answerbuttons
     *
     * First removes all "old" answer buttons then loads question from questionpool and displays it on gui. after that
     * answerbutton will be generated and attatched to gui 
     */
    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    
    /**
     * @brief removes all answerbuttons gameobjects from gui 
     *
     * removes all answerbuttons gameobjects from gui 
     */
    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }


    /**
   * @brief handling of what is happening when answebutton is clicked 
   *
   * Checks if the answer is correct or false. Show the Display of correctAnswer/badAnswer.
     * Loads new Question if Questionpool isnt at max. If all questions are asked, the game is over.
   */
    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            StartCoroutine(correctAnswerDisplay());
        }
        else
        {
            playerScore -= currentRoundData.pointsAddedForCorrectAnswer;
            StartCoroutine(badAnswerDisplay());
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }

        //Wait for 4 seconds
    }

    /**
   * @brief Display that the Answer was correct 
   *
   * Shows a litte banner for a seconds which indicates the player that he answered right
   */
    IEnumerator correctAnswerDisplay()
    {
        StartCoroutine(colorChangingGood());
        correctDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        correctDisplay.SetActive(false);
    }
    
    /**
* @brief Display that the Answer was false 
*
* Shows a litte banner for a seconds which indicates the player that he answered false
*/
    IEnumerator badAnswerDisplay()
    {
     
        StartCoroutine(colorChangingBad());
    
        badDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        badDisplay.SetActive(false);
    }

    /**
* @brief Fading the Bad Display oppacity
*
*/
    IEnumerator colorChangingBad()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {   
            Image bg = badDisplay.GetComponent<Image>();
            bg.color = new Color(1, 0, 0, i);
            yield return null;
        }
    }

    /**
* @brief Fading the Goold Display oppacity
*
*/
    IEnumerator colorChangingGood()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                Image bg = correctDisplay.GetComponent<Image>();
                bg.color = new Color(0, 1, 0, i);
                yield return null;
            }
        }


    /**
* @brief Ends the round
*
     * removes all buttons and shows the endgame display
*/
    public void EndRound()
    {
        RemoveAnswerButtons();
        questionDisplayText.text = "";
        scoreDisplayText.text = "You reached " + playerScore + " Points";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }
    
    /**
* @brief return to the MenuScene
*
*/

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    
}