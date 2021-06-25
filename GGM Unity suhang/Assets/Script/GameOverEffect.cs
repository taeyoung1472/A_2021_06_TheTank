using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverEffect : MonoBehaviour
{
    [SerializeField]
    private Image gameOver;
    [SerializeField]
    private GameObject backBtn;
    private float speed = 1;
    void Update()
    {
        if (gameOver.fillAmount < 1)
        {
            gameOver.fillAmount += Time.deltaTime * 0.5f;
        }
        else
        {
            Time.timeScale = 0;
            backBtn.SetActive(true);
        }
    }
}
