﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    public void StartClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
