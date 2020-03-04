using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGrenade : MonoBehaviour
{
    public float lifetime;
    private float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        Enemy curEnemy = checkCollision.GetComponent<Enemy>();

        if (curEnemy != null)
        {
            curEnemy.hp -= 2;
        }
    }
}
