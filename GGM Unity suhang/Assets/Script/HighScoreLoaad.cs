using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreLoaad : MonoBehaviour
{
    [SerializeField]
    private Text bestTxt;
    [SerializeField]
    private Text bestHardTxt;
    private int bestScore;
    private int bestScoreHard;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best");
        bestScoreHard = PlayerPrefs.GetInt("HardBest");
        bestTxt.text = string.Format("BEST : {0}", bestScore);
        bestHardTxt.text = string.Format("BEST : {0}", bestScoreHard);
    }
}
