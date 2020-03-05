using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBugs : MonoBehaviour
{
    public int direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * direction);

        if(transform.position.x > 7.3f && direction == 1)
        {
            transform.Translate(transform.right * -7.3f * 2);
        }
        else if (transform.position.x < -7.3f && direction == -1)
        {
            transform.Translate(transform.right * 7.3f * 2);
        }
    }
}
