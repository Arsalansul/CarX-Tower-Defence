using UnityEngine;

public abstract class BaseTower : MonoBehaviour, ITower
{
    [Header("Base Tower Settings")]
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected Transform turret;
    
    protected float lastShotTime;
    protected ITargetable currentTarget;
    protected BaseProjectile currentProjectile;
    protected string projectilePoolName;
    
    private TowerConfig config;

    protected TowerConfig Config
    {
        get
        {
            if (config == null && ConfigManager.Instance != null)
            {
                config = GetConfig();
            }
            return config;
        }
    }

    public float AttackRange => Config.AttackRange;
    public float ScanRange => Config.ScanRange;

    protected abstract TowerConfig GetConfig();
    
    public bool HasTarget => currentTarget != null && currentTarget.IsAlive;
    public ITargetable CurrentTarget => currentTarget;
    
    private bool CanShoot => Time.time >= lastShotTime + Config.ShootInterval;

    private bool canHit;
    
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterTower(this);
        }
        
        lastShotTime = - Config.ShootInterval;
        projectilePoolName = Config.ProjectilePrefab.PoolName;
    }
    
    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UnregisterTower(this);
        }
    }
    
    void Update()
    {
        UpdateTargeting();
        canHit = HasTarget && TargetingSystem.CanHitTarget(shootPoint.position, currentTarget.Position, currentTarget.Velocity, Config.ProjectilePrefab.Speed, AttackRange);
        
        if (CanShoot && canHit)
        {
            Shoot();
        }
    }

    public virtual void UpdateTargeting()
    {
        if (currentTarget != null && currentTarget.IsAlive && canHit) return;
        
        currentTarget = GameManager.Instance.GetClosestTarget(transform.position, ScanRange);
    }
    
    protected virtual void Shoot()
    {
        if (Config.ProjectilePrefab == null || shootPoint == null) return;
        
        currentProjectile = PoolManager.Instance.GetProjectileFromPool(projectilePoolName);
        InitializeProjectile();
        
        lastShotTime = Time.time;
        GameEvents.InvokeTowerShoot(this);
    }

    protected virtual void InitializeProjectile()
    {
        currentProjectile.transform.position = shootPoint.position;
        currentProjectile.transform.rotation = shootPoint.rotation;
        currentProjectile.Initialize(currentTarget.Position - shootPoint.transform.position);
    }
}