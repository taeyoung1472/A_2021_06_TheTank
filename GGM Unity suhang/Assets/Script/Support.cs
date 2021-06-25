﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Support : MonoBehaviour
{
    public int hp;
    public AudioSource audio;
    public Image image;
    public Button button;
    public float coolTime = 10.0f;
    public bool isClicked = false;
    float leftTime = 10.0f;
    float speed = 5.0f;
    void Update()
    {
        if (isClicked)
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if (leftTime < 0)
                {
                    leftTime = 0;
                    if (button)
                        button.enabled = true;
                    isClicked = true;
                }

                float ratio = 1.0f - (leftTime / coolTime);
                if (image)
                    image.fillAmount = ratio;
            }
    }
    public void StartCoolTime()
    {
        audio.Play();
        leftTime = coolTime;
        isClicked = true;
        if (button)
            button.enabled = false;
    }
}
