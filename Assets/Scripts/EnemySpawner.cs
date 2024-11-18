using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;
    
    private void Start() {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;
            int random = Random.Range(0, enemyPrefabs.Length);

            GameObject enemyToSpawn = enemyPrefabs[random];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
