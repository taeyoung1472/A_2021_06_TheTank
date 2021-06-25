using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClear : MonoBehaviour
{
    public GameObject Explosion;
    void Update()
    {
        if(transform.position.y < -3)
        {
            Instantiate(Explosion.transform, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
