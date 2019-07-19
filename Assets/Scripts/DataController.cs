using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * @class DataCongfolldf
 *
 * @brief Holds all Rounddata
 */
public class DataController : MonoBehaviour
{ 
    /// <summary>
    /// allRoundData - carries data of alle rounds
    /// </summary>
    public RoundData[] allRoundData;

    
    /**
     * @brief returns the current round data 
     * 
     */
    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }
}