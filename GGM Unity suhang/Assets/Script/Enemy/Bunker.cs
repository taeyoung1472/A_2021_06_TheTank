using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : EnemyMove
{
    private bool isStop = false;
    protected override void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < 9 && isStop == false)
        {
            speed = 0;
            StartCoroutine(Shoot());
            isStop = true;
            //speed = 0;
        }
        if (hp <= 0)
        {
            gameManager.GetScore(score);
            Debug.Log("A");
            Destroy(gameObject);
        }
    }
}
