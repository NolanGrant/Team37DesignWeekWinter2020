using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternSpawner : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject pattern;

    public int currentDifficulty = 0;

    [Header("difficulty pattern pools")]
    public GameObject[] difficulty0Patterns;
    public GameObject[] difficulty1Patterns;
    public GameObject[] difficulty2Patterns;
    public GameObject[] difficulty3Patterns;
    public GameObject[] difficulty4Patterns;
    public GameObject[] difficulty5Patterns;

    [Header("patternsToProgressDifficultyLevel")]
    public int[] patternsToProgressDifficultyLevel;

    private void Awake()
    {
        patternsToProgressDifficultyLevel[0] = difficulty0Patterns.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectPatternToSpawn();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectPatternToSpawn()
    {
        if (currentDifficulty == 0)
        {
            SpawnSelectedPattern(difficulty0Patterns);
        }
        if (currentDifficulty == 1)
        {
            SpawnSelectedPattern(difficulty1Patterns);
        }
        if (currentDifficulty == 2)
        {
            SpawnSelectedPattern(difficulty2Patterns);
        }
        if (currentDifficulty == 3)
        {
            SpawnSelectedPattern(difficulty3Patterns);
        }
        if (currentDifficulty == 4)
        {
            SpawnSelectedPattern(difficulty4Patterns);
        }
        if (currentDifficulty == 5)
        {
            SpawnSelectedPattern(difficulty5Patterns);
        }
    }

    int difficulty0Progression = 0;
    void SpawnSelectedPattern(GameObject[] patternsToSpawnFrom)
    {
        GameObject newPattern;
        if (currentDifficulty == 0)
        {
            newPattern = Instantiate(patternsToSpawnFrom[Mathf.Clamp(difficulty0Progression, 0, difficulty0Patterns.Length)], spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            newPattern = Instantiate(patternsToSpawnFrom[Random.Range(0, patternsToSpawnFrom.Length)], spawnPoint.transform.position, Quaternion.identity);
        }
        PatternMover newPatternScript = newPattern.GetComponent<PatternMover>();
        newPatternScript.mySpawner = this;
    }

    public void TrailerPassed()
    {
        SelectPatternToSpawn();
    }
}
