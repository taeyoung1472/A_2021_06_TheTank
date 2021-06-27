using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject setting;
    public void UseSetting()
    {
        setting.SetActive(true);
    }
    public void Exit()
    {
        setting.SetActive(false);
    }
    public void OnTurn()
    {
        PlayerPrefs.SetInt("Turn", 1);
    }
    public void OffTurn()
    {
        PlayerPrefs.SetInt("Turn", 0);
    }
}
