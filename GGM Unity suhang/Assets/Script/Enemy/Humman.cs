using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humman : EnemyMove
{
    private bool isStop = false;
    private float stopPos;
    private void Awake()
    {
        stopPos = Random.Range(customStopPos.x, customStopPos.y);
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
