using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/**
 * @class AnswerData
 *
 * @brief AnswerData Objects are generated out of that Template
 *
 * AnswerData holds information about the actual answerText and if the answer is the correct one
 */
public class AnswerData
{
    /// <summary>
    /// AnswerText - carries AnswerText
    /// </summary>
    public string answerText;
    /// <summary>
    /// isCorrect - true if answer is correct, false when not
    /// </summary>
    public bool isCorrect;

}

