using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTakeDamage : MonoBehaviour
{
    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        EnemyMovement enemy = col.GetComponent<EnemyMovement>();

        if(enemy != null)
        {
            arm.GetComponent<ArmHealth>().currentHealth -= 25;
        }
        
    }
}
