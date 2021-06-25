using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float speed;
    public int damage;
    private GameManager gameManager;
    private void Awake()
    {
        //gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //gameManager.Damaged(damage);
            Destroy(gameObject);
        }
    }
}