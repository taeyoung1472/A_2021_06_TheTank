using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public int damage;
    private PoolManager pool;
    [SerializeField]
    private bool isPooling;
    private void Awake()
    {
        pool = FindObjectOfType<PoolManager>();
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(transform.position.x > 12)
        {
            if(isPooling == true)
            {
                gameObject.SetActive(false);
                transform.SetParent(pool.transform);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
