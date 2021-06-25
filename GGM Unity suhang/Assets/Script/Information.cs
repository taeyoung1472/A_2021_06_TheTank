using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject[] information;
    public void informationUse()
    {
        information[0].SetActive(true);
    }
    public void informationUse1()
    {
        information[0].SetActive(true);
        information[1].SetActive(false);
    }
    public void informationUse2()
    {
        information[2].SetActive(false);
        information[1].SetActive(true);
        information[0].SetActive(false);
    }
    public void informationUse3()
    {
        information[2].SetActive(true);
        information[1].SetActive(false);
    }
    public void informationExit()
    {
        information[0].SetActive(false);
        information[1].SetActive(false);
        information[2].SetActive(false);
    }
}
