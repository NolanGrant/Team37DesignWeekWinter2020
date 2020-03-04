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

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveEnemies == 0)
        {
            SpawnEnemyWave();
        }
    }

    private void SpawnEnemyWave()
    {

        for (int i = 0; i < SpawnPoints.Length; i++)
        {

            int lineType = Random.Range(leastDifficultLine, mostDifficultLine + 1);
            Instantiate(LineTypes[lineType - 1], SpawnPoints[i].position, Quaternion.identity);

        }
        
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
