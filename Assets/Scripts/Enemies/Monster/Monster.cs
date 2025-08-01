using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IEnemy, ITargetable
{
    public HealthComponent HealthComponent
    {
        get
        {
            if (healthComponent == null)
            {
                healthComponent = gameObject.GetComponent<HealthComponent>();
            }

            return healthComponent;
        }
    }

    public MovementComponent MovementComponent
    {
        get
        {
            if (movementComponent == null)
            {
                movementComponent = gameObject.GetComponent<MovementComponent>();
            }
            return movementComponent;
        }
    }
    private EnemyConfig config;

    protected EnemyConfig Config
    {
        get
        {
            if (config == null && ConfigManager.Instance != null)
            {
                config = ConfigManager.Instance.GetMonsterConfig();
            }
            return config;
        }
    }
    
    public string PoolName => Config.PoolName;

    public Vector3 Position => transform.position;
    public Vector3 Velocity => movementComponent.Velocity;
    public bool IsAlive => HealthComponent.IsAlive;

    private HealthComponent healthComponent;
    private MovementComponent movementComponent;
    
    private void Start()
    {
        MovementComponent.OnTargetReached += OnTargetReached;
        HealthComponent.OnDeath += OnDeath;
    }
    
    private void OnDestroy()
    {
        MovementComponent.OnTargetReached -= OnTargetReached;
        HealthComponent.OnDeath -= OnDeath;
        GameManager.Instance.UnregisterTarget(this);
    }
    
    private void OnTargetReached()
    {
        PoolManager.Instance.ReturnEnemyToPool(PoolName, this);
        GameManager.Instance.UnregisterTarget(this);
        HealthComponent.OnReturnToPool();
    }
    
    private void OnDeath()
    {
        PoolManager.Instance.ReturnEnemyToPool(PoolName, this);
        GameManager.Instance.UnregisterTarget(this);
        HealthComponent.OnReturnToPool();
    }
    
    public void Initialize(Queue<Vector3> movePoints)
    {
        MovementComponent.OnGetFromPool(movePoints, Config.Speed, Config.ReachDistance);
        HealthComponent.OnGetFromPool(Config.MaxHealth);
        GameManager.Instance.RegisterTarget(this);
    }
    
    public void TakeDamage(int damage)
    {
        healthComponent.TakeDamage(damage);
    }
} 