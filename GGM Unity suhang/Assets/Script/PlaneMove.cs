using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    [SerializeField]
    private float RPM;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bullet;
    void Start()
    {
        StartCoroutine(Fire());
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(RPM);
            Instantiate(bullet,new  Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
        }
    }
}
