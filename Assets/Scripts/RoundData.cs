using UnityEngine;
using System.Collections;

[System.Serializable]

/**
 * @class RoundData
 *
 * @brief Holds all information about the actual Round e.g. Points and Questiondata 
 */
public class RoundData 
{
    /// <summary>
    /// Increment of Score
    /// </summary>
    public int pointsAddedForCorrectAnswer;
    /// <summary>
    /// Cary all Questions of actual Round
    /// </summary>
    public QuestionData[] questions;

}