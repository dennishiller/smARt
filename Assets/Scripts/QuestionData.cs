using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/**
 * @class QuestionData
 *
 * @brief QuestionData Objects are generated out of that Template
 *
 * Questiondata holds information about the actual questiontext and the possible answers
 */
public class QuestionData
{
    /// <summary>
    /// QuestionText
    /// </summary>
   public string questionText;
    /// <summary>
    /// Answers - Array of all possible Answers
    /// </summary>
   public AnswerData[] answers;
}
