﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public GameObject[] bullet;
    public float speed;
    public float[] fireDelay;
    public Transform[] bulletPos;
    public GameObject[] support;
    public Vector2 mouse;
    public float[] posY = {-4,-2,0,2,4};
    public int n;
    public int fuel = 10;
    public Slider fuelSlider;
    public bool canMove = true;
    public bool isGunShoot = false;
    public bool isCannonShoot = false;
    public int basehp;
    public int hp;
    public AudioSource[] audio;
    public Text baseHpText;
    public Button[] supportBtn;
    public Slider hpSlider;
    public GameManager game;
    void Start()
    {
        hpSlider.value = hp * 0.001f;
        game = FindObjectOfType<GameManager>();
        StartCoroutine(Fuel());
        StartCoroutine(Fuelsystem());
        StartCoroutine(FireGun());
        StartCoroutine(FireCannon());
    }
    private void Update()
    {
        if (hp > 1000)
            hp = 1000;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            game.Damaged(collision.transform.GetComponent<EnemyBulletMove>().damage);
            //hpSlider.value = hp * 0.001f;
        }
        if (collision.transform.tag == "Item")
        {
            game.Damaged(collision.transform.GetComponent<Item>().value * -1);
            Destroy(collision.gameObject);
            //hpSlider.value = hp * 0.001f;
        }
    }
    public void UIupdate()
    {
        fuelSlider.value = fuel * 0.1f;
    }
    public void OnShootC()
    {
        isCannonShoot = true;
    }
    public void EndShootC()
    {
        isCannonShoot = false;
    }
    private IEnumerator FireCannon()
    {
        while (true)
        {
            if (isCannonShoot == true)
            {
                audio[0].Play();
                GameObject Bullet;
                Bullet = Instantiate(bullet[0], bulletPos[0].position, Quaternion.identity);
                bullet[0].transform.SetParent(null);
                yield return new WaitForSeconds(fireDelay[0]);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator FireGun()
    {
        while (true)
        {
            if (isGunShoot == true)
            {
                audio[1].Play();
                GameObject Bullet;
                Bullet = Instantiate(bullet[1], bulletPos[1].position, Quaternion.identity);
                bullet[1].transform.SetParent(null);
            }
            yield return new WaitForSeconds(fireDelay[1]);
        }
    }
    public void up()
    {
        if (canMove == true)
        {
            n += 1;
            StartCoroutine(ChangePos());
        }
    }
    public void down()
    {
        if(canMove == true) 
        {
            n -= 1;
            StartCoroutine(ChangePos());
        }
    }
    public void OnShootG()
    {
        isGunShoot = true;
    }
    public void EndShootG()
    {
        isGunShoot = false;
    }
    private IEnumerator ChangePos()
    {
        if(fuel <= 1)
        {
            canMove = false;
        }
        if (n >= 4)
        {
            n = 4;
        }
        if (n <= 0)
        {
            n = 0;
        }
        fuel--;
        audio[2].Play();
        UIupdate();
        transform.position = new Vector3(-5, posY[n], 0);
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator Fuel()
    {
        while (true)
        {
            fuel++;
            if(fuel >= 10)
            {
                fuel = 10;
            }
            yield return new WaitForSeconds(2f);
        }
    }
    private IEnumerator Fuelsystem()
    {
        while (true)
        {
            if (fuel < 10)
            {
                fuel++;
                if (fuel > 0)
                {
                    canMove = true;
                }
            }
            UIupdate();
            yield return new WaitForSeconds(1f);
        }
    }
    public void CallBomber()
    {
        Instantiate(support[1]);
    }
    public void CallPlane()
    {
        Instantiate(support[0],new Vector3(-12.5f,transform.position.y,transform.position.z),Quaternion.identity);
    }
}
