using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humman : EnemyMove
{
    public bool isStop = false;
    public float stopPos;
    private void Awake()
    {
        stopPos = Random.Range(-1, 6);
    }
    protected override void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < stopPos && isStop == false)
        {
            StartCoroutine(Shoot());
            speed = 0;
            isStop = true;
        }
        if (hp <= 0)
        {
            gameManager.GetScore(score);
            //Debug.Log("A");
            Destroy(gameObject);
        }
    }
}
