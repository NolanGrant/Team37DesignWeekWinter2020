using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSetUp : MonoBehaviour
{
    //types of lines
    [SerializeField]
    GameObject[] LineTypes;

    [SerializeField]
    Transform[] SpawnPoints;

    [SerializeField]
    int leastDifficultLine = 0;

    [SerializeField]
    int mostDifficultLine = 3;

    private int aliveEnemies;

    private int wavesSpwned;

    [SerializeField]
    float spawnRate;

    [SerializeField]
    float TimeBetweenWaves;

    void Start()
    {
        InvokeRepeating("SpawnEnemyWave", 1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (wavesSpwned > 2)
        {
            StartCoroutine(WaitForNextWave());
        }
    }

    IEnumerator WaitForNextWave() 
    {
        wavesSpwned = 0;
        CancelInvoke("SpawnEnemyWave");
        yield return new WaitForSeconds(TimeBetweenWaves);
        InvokeRepeating("SpawnEnemyWave", 0, spawnRate);
    }
    

    private void SpawnEnemyWave()
    {

        for (int i = 0; i < SpawnPoints.Length; i++)
        {

            int lineType = Random.Range(leastDifficultLine, mostDifficultLine + 1);
            Instantiate(LineTypes[lineType - 1], SpawnPoints[i].position, Quaternion.identity);
            

        }

        wavesSpwned++;
        
    }

    public void IncreaseAliveEnemies() 
    {
        aliveEnemies++;
    }

    public void DecreaseAliveEnemies() 
    {
        aliveEnemies--;
    }


}
