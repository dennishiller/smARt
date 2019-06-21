using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public GameObject correctDisplay;
    public GameObject badDisplay;


    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;


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


    //      var colors = GetComponents<Button> ().colors;
    //      colors.normalColor = Color.red;
    //      GetComponent<Button> ().colors = colors;


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
            StartCoroutine(basAnswerDisplay());
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
        correctDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        correctDisplay.SetActive(false);
    }
    IEnumerator basAnswerDisplay()
    {
        badDisplay.SetActive(true);
        yield return new WaitForSeconds(1f);
        badDisplay.SetActive(false);
    }

    public void EndRound()
    {
        isRoundActive = false;
        Debug.Log(playerScore);


        scoreDisplayText.text = "You reached " + playerScore + " Points";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }


    // Update is called once per frame
    void Update()
    {
    }
}