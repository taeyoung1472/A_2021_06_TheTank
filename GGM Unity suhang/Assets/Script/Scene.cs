using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    [SerializeField]
    private GameObject choicePannel;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void StartClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void ChoiceDiff()
    {
        choicePannel.SetActive(true);
    }
    public void Exit()
    {
        choicePannel.SetActive(false);
    }
    public void Hard()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
    }
    public void Easy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }
}
