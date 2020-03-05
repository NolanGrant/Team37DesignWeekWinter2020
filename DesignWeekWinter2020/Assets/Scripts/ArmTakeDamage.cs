using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTakeDamage : MonoBehaviour
{
    public GameObject arm;

    ArmHealth armHp;

    private void Awake()
    {
        armHp = GetComponentInParent<ArmHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;

        EnemyMovement enemy = col.GetComponent<EnemyMovement>();

        if (enemy != null)
        {
            armHp.currentHealth -= 25;
        }
    }
}
