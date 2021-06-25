using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int score;
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float[] armor;
    private PlayerMove player;
    private GameObject playerObj;
    protected GameManager gameManager;
    [SerializeField]
    private float RPM;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private float shootRound;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private bool isZoom;
    private float rotationZ = 0f;
    private Vector2 diff = Vector2.zero;
    [SerializeField]
    private int customRotaitonZFix;
    [SerializeField]
    protected Vector2 customStopPos;
    [SerializeField]
    private AudioSource fire;
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
                fire.Play();
                yield return new WaitForSeconds(RPM);
            }
            yield return new WaitForSeconds(reloadTime);
        }
    }
}
