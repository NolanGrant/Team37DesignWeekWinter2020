using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("RightWeapon") ||
            collision.gameObject.layer == LayerMask.NameToLayer("LeftWeapon"))
        {
            collision.GetComponentInParent<ArmHealth>().currentHealth = 0;

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
