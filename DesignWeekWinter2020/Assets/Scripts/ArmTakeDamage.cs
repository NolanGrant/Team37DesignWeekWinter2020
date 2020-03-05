using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTakeDamage : MonoBehaviour
{
    public GameObject arm;

    ArmHealth armHp;

    CameraShake camShake;

    private void Awake()
    {
        armHp = GetComponentInParent<ArmHealth>();

        camShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        GameObject col = collision.gameObject;

        EnemyMovement enemy = col.GetComponent<EnemyMovement>();

        if (enemy != null)
        {
            camShake.SmallImpact();
            armHp.currentHealth -= 10;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("OnlyInteractEnemies"))
        {
            Debug.Log("Hit");
            armHp.currentHealth -= 200;

        }
    }
}
