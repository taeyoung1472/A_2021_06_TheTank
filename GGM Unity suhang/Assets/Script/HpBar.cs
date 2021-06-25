using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public EnemyMove enemy;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        enemy = FindObjectOfType<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 1 / 2;
        if(enemy.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
