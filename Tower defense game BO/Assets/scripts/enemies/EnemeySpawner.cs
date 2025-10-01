using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float time = 1f;

    IEnumerator SpawnEnemy()
        {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
