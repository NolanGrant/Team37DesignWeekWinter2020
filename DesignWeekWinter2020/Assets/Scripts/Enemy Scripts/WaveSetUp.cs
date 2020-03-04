using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSetUp : MonoBehaviour
{
    //types of lines
    [SerializeField]
    GameObject[] LineTypes;



    [SerializeField]
    float spaceBetweenLines;

    GameObject[] currentWavesAlive;

    int spawnedWavesCount = 0;

    GameObject[] waveType1;
    GameObject[] waveType2;
    GameObject[] waveType3;

    [SerializeField]
    int[] waveOrder;


    void Start()
    {
        //Create Wave Types
        waveType1 = new GameObject[4] { LineTypes[1], LineTypes[0], LineTypes[1], LineTypes[0] };
        waveType2 = new GameObject[4] { LineTypes[0], LineTypes[0], LineTypes[2], LineTypes[2] };
        waveType3 = new GameObject[4] { LineTypes[2], LineTypes[0], LineTypes[0], LineTypes[2] };



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnEnemyWave();
        }
    }

    private void SpawnEnemyWave()
    {

        for (int i = 0; i < waveOrder.Length; i++)
        {
            GameObject[] currentWaveArr = GetNextWave(i + 1);
            for (int q = 0; q < currentWaveArr.Length; q++)
            {
                Vector3 NextPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (spaceBetweenLines * (i + q)), gameObject.transform.position.z);
                Instantiate(currentWaveArr[q], NextPosition, Quaternion.identity);

            }
        }
    }

    private GameObject[] GetNextWave(int WaveNumber)
    {
        if (WaveNumber == 1)
        {
            return waveType1;
        }
        else if (WaveNumber == 2)
        {
            return waveType2;
        }
        else if (WaveNumber == 3)
        {
            return waveType3;
        }

        else

        {
            return null;
        }



    }
}
