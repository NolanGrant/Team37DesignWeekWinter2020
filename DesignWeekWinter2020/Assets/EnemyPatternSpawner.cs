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

    public bool canGoToLevel1 = true;

    public int difficulty0Progression = 0;

    public int currentLevelPatternProgress = 0;

    int highLevelSpeedIncrementer;
    float highLevelSpeedamount = .2f;

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


    void SpawnSelectedPattern(GameObject[] patternsToSpawnFrom)
    {
        GameObject newPattern;
        if (currentDifficulty == 0)
        {
            newPattern = Instantiate(patternsToSpawnFrom[Mathf.Clamp(difficulty0Progression, 0, difficulty0Patterns.Length - 1)], spawnPoint.transform.position, Quaternion.identity);
            difficulty0Progression += 1;
        }
        else
        {
            newPattern = Instantiate(patternsToSpawnFrom[Random.Range(0, patternsToSpawnFrom.Length)], spawnPoint.transform.position, Quaternion.identity);
        }
        PatternMover newPatternScript = newPattern.GetComponent<PatternMover>();
        newPatternScript.mySpawner = this;
        if(currentLevelPatternProgress >= 10)
        {
            newPatternScript.movespeed += Mathf.Clamp(currentLevelPatternProgress - 10, 0, 5) * highLevelSpeedamount;
        }
    }

    public float breakBetweenLevels = 1.5f;

    public void TrailerPassed()
    {
        if (currentDifficulty >= 1)
        {
            currentLevelPatternProgress += 1;
        }

        if (difficulty0Progression >= difficulty0Patterns.Length && canGoToLevel1 == true)
        {
            canGoToLevel1 = false;
            currentDifficulty = 1;
            currentLevelPatternProgress = 0;

            Invoke("SelectPatternToSpawn", breakBetweenLevels);
        }

        else if (currentLevelPatternProgress >= patternsToProgressDifficultyLevel[currentDifficulty])
        {
            currentLevelPatternProgress = 0;
            currentDifficulty = Mathf.Clamp(currentDifficulty + 1, 0, 5);

            Invoke("SelectPatternToSpawn", breakBetweenLevels);
        }
        else
        {
            SelectPatternToSpawn();
        }
    }
}
