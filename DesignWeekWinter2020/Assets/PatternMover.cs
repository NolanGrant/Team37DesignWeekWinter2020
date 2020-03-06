using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMover : MonoBehaviour
{
    public float movespeed;

    public EnemyPatternSpawner mySpawner;

    public GameObject trailer;
    bool canSpawnNextWave = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + (Vector3)(Vector2.down * movespeed * Time.fixedDeltaTime);

        if (trailer.transform.position.y < mySpawner.spawnPoint.transform.position.y && canSpawnNextWave == true)
        {
            canSpawnNextWave = false;
            mySpawner.SelectPatternToSpawn();
        }
    }
}
