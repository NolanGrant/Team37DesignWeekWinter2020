using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternSpawner : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject pattern;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPattern()
    {
        GameObject newPattern = Instantiate(pattern, spawnPoint.transform.position, Quaternion.identity);
        PatternMover newPatternScript = newPattern.GetComponent<PatternMover>();
        newPatternScript.mySpawner = this;
    }

    public void TrailerPassed()
    {
        SpawnPattern();
    }
}
