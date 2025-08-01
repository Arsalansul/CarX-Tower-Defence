using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float lastSpawn;
    
    private void Start()
    {
        lastSpawn = -GameManager.Instance.Config.EnemySpawnInterval;
    }
    
    private void Update()
    {
        if (Time.time > lastSpawn + GameManager.Instance.Config.EnemySpawnInterval)
        {
            SpawnMonster();
            lastSpawn = Time.time;
        }
    }
    
    private void SpawnMonster()
    {
        var monster = PoolManager.Instance.GetEnemyFromPool(GameManager.Instance.Config.EnemyName);
        monster.transform.position = GameManager.Instance.Config.MovePoints[0];
        monster.transform.rotation = Quaternion.identity;
        monster.Initialize( new Queue<Vector3>(GameManager.Instance.Config.MovePoints));
    }
} 