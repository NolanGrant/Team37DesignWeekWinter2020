using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public float cooldown;
    private float downTimer = 0;

    public float speed;
    public float distance;
    public float sizeGain;
    private Vector3 origin;

    public GameObject bomb;

    GameObject curBomb;

    public bool shootTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Guns>().triggerShoot && downTimer <= 0)
        {
            Debug.Log("Shoot");
            GameObject instantiatedBomb = GameObject.Instantiate(bomb, transform.position, transform.rotation) as GameObject;
            instantiatedBomb.GetComponent<Grenade>().speed = speed;
            instantiatedBomb.GetComponent<Grenade>().distance = distance;
            instantiatedBomb.GetComponent<Grenade>().sizeGain = sizeGain;
            curBomb = instantiatedBomb;
            downTimer = cooldown;
        }
        if(downTimer > 0)
        {
            downTimer -= Time.deltaTime;
        }
        else if (downTimer < 0)
        {
            downTimer = 0;
        }

        GetComponent<Guns>().triggerShoot = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * distance);
    }
}
