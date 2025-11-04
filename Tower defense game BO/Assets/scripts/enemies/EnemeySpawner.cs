using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EnemeySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private float timeBetweenEnemy = 1f;
    [SerializeField] private int BaseEnemies = 10;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float diffScalingFactor = 0.75f;

    public int waveNumber = 1;
    private float timeSinceSpawn;
    private int enemiesAlive;
    private int enemiesToSpawn;
    private bool isSpawning = false;

    public static UnityEvent onEnemyDestroy = new UnityEvent();
    public static event Action Waveincreased;

    private void Awake()
    {
        onEnemyDestroy.AddListener(Enemydestroyed);
    }

    private void Enemydestroyed()
    {
        enemiesAlive--;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(waveNumber, diffScalingFactor));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= (1f / timeBetweenEnemy) && enemiesToSpawn > 0)
        {
            timeSinceSpawn = 0f;
            enemiesToSpawn--;
            enemiesAlive++;
            SpawnEnemy();

        }

        if (enemiesAlive == 0 && enemiesToSpawn == 0)
        {
            Endwave();
        }

    }

    private IEnumerator StartWave()
    {
        Waveincreased?.Invoke();
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesToSpawn = EnemiesPerWave();
    }

    private void Endwave()
    {
        isSpawning = false;
        timeSinceSpawn = 0f;
        StartCoroutine(StartWave());
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefab[0];
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
