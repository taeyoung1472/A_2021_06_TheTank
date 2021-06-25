using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreLoaad : MonoBehaviour
{
    [SerializeField]
    private Text bestTxt;
    private int bestScore;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best");
        bestTxt.text = string.Format("BEST : {0}", bestScore);
    }
}
