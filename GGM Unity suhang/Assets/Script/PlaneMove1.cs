using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove1 : MonoBehaviour
{
    [SerializeField]
    private float RPM;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private Transform FirePos;
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
