using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    public float speed;
    public int score;
    public float hp;
    public float[] armor;
    private PlayerMove player;
    private GameObject playerObj;
    public GameManager gameManager;
    public float RPM;
    public float reloadTime;
    public Transform firePos;
    public float shootRound;
    public GameObject Bullet;
    public bool isZoom;
    private float rotationZ = 0f;
    private Vector2 diff = Vector2.zero;
    public int customRotaitonZFix;
    public Vector2 customStopPos;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerMove>();
    }

    protected virtual void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (hp <= 0)
        {
            gameManager.GetScore(score);
            Destroy(gameObject);
        }
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "Bullet")
        {
            hp -= coll.gameObject.GetComponent<BulletMove>().damage / armor[0];
            Destroy(coll.gameObject);
        }
        if (coll.transform.tag == "SmallBullet")
        {
            hp -= coll.gameObject.GetComponent<BulletMove>().damage / armor[1];
            Destroy(coll.gameObject);
        }
        if(coll.transform.tag == "Bomb")
        {
            hp -= 10000;
        }
    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            for(int i = 0;i < shootRound; i++)
            {
                if(isZoom == true)
                {
                    diff = new Vector3(-5,player.posY[player.n],0) - transform.position;
                    diff.Normalize();
                    rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                    Instantiate(Bullet, firePos.position, Quaternion.Euler(0f, 0f, rotationZ + customRotaitonZFix));
                }
                else
                    Instantiate(Bullet, firePos.position, Quaternion.identity);
                yield return new WaitForSeconds(RPM);
            }
            yield return new WaitForSeconds(reloadTime);
        }
    }
}
