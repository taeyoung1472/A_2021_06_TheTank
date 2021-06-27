using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject TurnDefalut;
    [SerializeField]
    private GameObject TurnChange;
    void Start()
    {
        if(PlayerPrefs.GetInt("Turn") == 0)
        {
            TurnDefalut.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Turn") == 1)
        {
            TurnChange.SetActive(true);
        }
    }
}