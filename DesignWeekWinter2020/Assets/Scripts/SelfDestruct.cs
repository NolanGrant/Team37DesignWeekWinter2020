using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float lifespan = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", lifespan);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
