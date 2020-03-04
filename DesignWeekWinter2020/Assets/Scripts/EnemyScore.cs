using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    public float lifetime;
    public float speed;
    public float size;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.localScale = new Vector3(size, size, size);

        transform.Translate(transform.up * speed);

        if(timer >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
