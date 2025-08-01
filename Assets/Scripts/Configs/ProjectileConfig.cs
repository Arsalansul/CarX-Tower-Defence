using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Tower Defense/Projectile Config")]
public class ProjectileConfig : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private string poolName;
    
    public float Speed => speed;
    public int Damage => damage;
    public float Lifetime => lifetime;
    public string PoolName => poolName;
} 