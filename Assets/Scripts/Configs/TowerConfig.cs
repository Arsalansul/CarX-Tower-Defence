using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "Tower Defense/Tower Config")]
public class TowerConfig : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] private float shootInterval = 0.5f;
    [SerializeField] private float attackRange = 4f;
    [SerializeField] private float scanRange = 4f;
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private BaseProjectile projectilePrefab;
    [SerializeField] private CannonProjectileParabolic parabolicProjectilePrefab;
    
    [Header("Parabolic Settings")]
    [SerializeField] private bool useParabolicTrajectory = false;
    
    public float ShootInterval => shootInterval;
    public float AttackRange => attackRange;
    public float ScanRange => scanRange;
    public float RotationSpeed => rotationSpeed;
    public BaseProjectile ProjectilePrefab => projectilePrefab;
    public CannonProjectileParabolic ParabolicProjectilePrefab => parabolicProjectilePrefab;
    
    public bool UseParabolicTrajectory => useParabolicTrajectory;
} 