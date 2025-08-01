using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    
    [System.Serializable]
    public class EnemyPoolConfig
    {
        public Monster prefab;
        public int initialSize = 10;
    }
    
    [System.Serializable]
    public class ProjectilePoolConfig
    {
        public BaseProjectile prefab;
        public int initialSize = 10;
    }
    
    [SerializeField] private List<EnemyPoolConfig> enemyPoolConfigs;
    [SerializeField] private List<ProjectilePoolConfig> projectilesPoolConfigs;
    
    private Dictionary<string, ObjectPool<Monster>> enemyPools;
    private Dictionary<string, ObjectPool<BaseProjectile>> projectilesPools;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializePools();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializePools()
    {
        enemyPools = new Dictionary<string, ObjectPool<Monster>>();
        projectilesPools = new Dictionary<string, ObjectPool<BaseProjectile>>();
        
        foreach (var config in enemyPoolConfigs)
        {
            var poolParent = new GameObject(config.prefab.PoolName);
            poolParent.transform.SetParent(transform);
            var pool = new ObjectPool<Monster>(config.prefab, poolParent.transform, config.initialSize);
            enemyPools[config.prefab.PoolName] = pool;
        }
        
        foreach (var config in projectilesPoolConfigs)
        {
            var poolParent = new GameObject(config.prefab.PoolName);
            poolParent.transform.SetParent(transform);
            var pool = new ObjectPool<BaseProjectile>(config.prefab, poolParent.transform, config.initialSize);
            projectilesPools[config.prefab.PoolName] = pool;
        }
    }
    
    public Monster GetEnemyFromPool(string poolName)
    {
        return enemyPools.TryGetValue(poolName, out var pool) ? pool.Get() : null;
    }

    public BaseProjectile GetProjectileFromPool(string poolName)
    {
        return projectilesPools.TryGetValue(poolName, out var pool) ? pool.Get() : null;
    }
    
    public void ReturnEnemyToPool(string poolName, Monster obj)
    {
        if (enemyPools.ContainsKey(poolName))
        {
            enemyPools[poolName].Return(obj);
        }
    }
    
    public void ReturnProjectileToPool(string poolName, BaseProjectile obj)
    {
        if (projectilesPools.ContainsKey(poolName))
        {
            projectilesPools[poolName].Return(obj);
        }
    }
    
    public bool HasPool(string poolName)
    {
        return enemyPools.ContainsKey(poolName) || projectilesPools.ContainsKey(poolName);
    }
    
    public void ClearPool(string poolName)
    {
        if (enemyPools.ContainsKey(poolName))
        {
            enemyPools[poolName].Clear();
            return;
        }
        if (projectilesPools.ContainsKey(poolName))
        {
            projectilesPools[poolName].Clear();
        }
    }
    
    public void ClearAllPools()
    {
        foreach (var pool in enemyPools.Values)
        {
            pool.Clear();
        }
        foreach (var pool in projectilesPools.Values)
        {
            pool.Clear();
        }
    }
} 