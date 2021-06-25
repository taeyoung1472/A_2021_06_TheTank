using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private Transform bombPos;
    [SerializeField]
    private float coolTime;
    private bool isOn = true;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(transform.position.x > 15 && isOn == true)
        {
            StartCoroutine(Drop());
            isOn = false;
        }
        if (transform.position.x > 50)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Drop()
    {
        while (true)    
        {
            yield return new WaitForSeconds(coolTime);
            Instantiate(bomb, new Vector3(bombPos.position.x,bombPos.position.y,0), Quaternion.identity);
        }
    }
}
