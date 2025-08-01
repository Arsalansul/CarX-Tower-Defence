using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Tower Defense/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float reachDistance = 0.3f;
    [SerializeField] private string poolName;
    
    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public float ReachDistance => reachDistance;
    public string PoolName => poolName;
    
} 