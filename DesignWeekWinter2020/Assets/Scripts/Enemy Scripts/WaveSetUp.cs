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

    [SerializeField]
    int clustersPerWave;

    [SerializeField]
    int unlockRate;

    int unlockNextLine = 0;

    public bool ready = false;

    void Start()
    {
        //InvokeRepeating("SpawnEnemyWave", 1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (wavesSpwned > clustersPerWave && ready == true)
        {
            StartCoroutine(WaitForNextWave());
        }

    }

    IEnumerator WaitForNextWave() 
    {
        wavesSpwned = 0;
        unlockNextLine++;
        SwarmChange();
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

    private void SwarmChange() 
    {
        if (unlockNextLine%unlockRate == 0 && unlockNextLine>0)
        {
            mostDifficultLine++;
            mostDifficultLine = Mathf.Clamp(mostDifficultLine, 0, LineTypes.Length);

            if (mostDifficultLine>=(LineTypes.Length/2))
            {
                leastDifficultLine++;
                leastDifficultLine = Mathf.Clamp(leastDifficultLine, 0, LineTypes.Length/2);
            }
        }

    }


}
