using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy01Spawner;
    public GameObject enemy02Spawner;

    void Start()
    {
        enemy01Spawner.GetComponent<EnemySpawn>().ScheduleEnemySpawner();
        enemy02Spawner.GetComponent<EnemySpawn>().ScheduleEnemySpawner();
    }
}
