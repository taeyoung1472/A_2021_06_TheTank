using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    public int value;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
