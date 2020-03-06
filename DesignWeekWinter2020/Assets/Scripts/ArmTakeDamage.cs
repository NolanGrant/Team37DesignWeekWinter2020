using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTakeDamage : MonoBehaviour
{
    ArmHealth armHp;
    CameraShake camShake;


    private void Awake()
    {
        armHp = GetComponentInParent<ArmHealth>();

        camShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            camShake.SmallImpact();
            armHp.currentHealth -= 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("OnlyInteractEnemies"))
        {
            Debug.Log("Hit");
            armHp.currentHealth -= 200;
        }
    }
}
