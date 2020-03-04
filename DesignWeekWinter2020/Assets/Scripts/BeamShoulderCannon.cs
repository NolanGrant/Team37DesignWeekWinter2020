using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShoulderCannon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
