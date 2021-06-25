using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove1 : MonoBehaviour
{
    public float RPM;
    public float speed;
    public GameObject bullet;
    public AudioSource audio;
    public Transform FirePos;
    void Start()
    {
        StartCoroutine(Fire());
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            audio.Play();
            yield return new WaitForSeconds(RPM);
            Instantiate(bullet, FirePos.position,Quaternion.identity);
        }
    }
}
