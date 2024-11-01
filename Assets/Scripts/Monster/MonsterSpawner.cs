using System;
using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public int MonstersCount;
    private bool isCoroutineOn;
    private float monsterSpawnX;
    private float monsterSpawnZ; 
    System.Random rand;

    [SerializeField] public GameObject MonsterPrefab;

    private float _spawnDelay = 5f;
    private int setDefaultMonsterNum = 3;
    private WaitForSecondsRealtime _waitTime;

    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(_spawnDelay);
        rand = new System.Random();
        //StartMonsterSpawnCoroutine(setDefaultMonsterNum);
    }
    
    public void StartMonsterSpawnCoroutine(int monstersCount)
    {
        MonstersCount = monstersCount;
        StartCoroutine(SpawnMonster());
    }
    public void StopMonsterSpawnCoroutine()
    {
        if (isCoroutineOn)
        {
            StopCoroutine(SpawnMonster());
        }
    }

    IEnumerator SpawnMonster()
    {
        isCoroutineOn = true;

        while (MonstersCount >= 1)
        {
            monsterSpawnX = 
                (UnityEngine.Random.Range(7, 10) + (float)rand.NextDouble())
                * (UnityEngine.Random.Range(0, 2) * 2 - 1); // 1 또는 -1 생성 -> monsterSpawnX가 ±(7~9)의 값을 가짐
            monsterSpawnZ =
                (UnityEngine.Random.Range(7, 10) + (float)rand.NextDouble())
                * (UnityEngine.Random.Range(0, 2) * 2 - 1);

            GameObject Monster = 
                Instantiate(MonsterPrefab, 
                new Vector3(monsterSpawnX, 3, monsterSpawnZ), 
                Quaternion.identity);

            MonstersCount--;

            yield return _waitTime;
        }

        isCoroutineOn = false;
        //Destroy(gameObject);
    }
}