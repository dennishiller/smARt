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


    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        roundEndDisplay.SetActive(false);
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;
    }

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

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }


    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            StartCoroutine(correctAnswerDisplay());
            Debug.Log("NICE!");
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

    IEnumerator correctAnswerDisplay()
    {
        StartCoroutine(colorChangingGood());
        correctDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        correctDisplay.SetActive(false);
    }
    IEnumerator badAnswerDisplay()
    {
     
        StartCoroutine(colorChangingBad());
    
        badDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        badDisplay.SetActive(false);
    }

    
    IEnumerator colorChangingBad()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {   
            Image bg = badDisplay.GetComponent<Image>();
            // set color with i as alpha
            bg.color = new Color(1, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator colorChangingGood()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                Image bg = correctDisplay.GetComponent<Image>();
                // set color with i as alpha
                bg.color = new Color(0, 1, 0, i);
                yield return null;
            }
        }


    public void EndRound()
    {
        isRoundActive = false;
        RemoveAnswerButtons();
        questionDisplayText.text = "";
        Debug.Log(playerScore);


        scoreDisplayText.text = "You reached " + playerScore + " Points";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    
}