using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyCol());
    }
    private IEnumerator DestroyCol()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
