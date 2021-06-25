using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSCheck : MonoBehaviour
{
    float deltaTime = 0f;
    public Text FPStext;
    void Start()
    {
        StartCoroutine(FpsCheckcol());
    }
    private IEnumerator FpsCheckcol()
    {
        while (true)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 1f;
            float fps = Mathf.Round(1 / Time.deltaTime);
            FPStext.text = string.Format("FPS:{0}", fps);
            yield return new WaitForSeconds(0.1f);
        }
    }
}