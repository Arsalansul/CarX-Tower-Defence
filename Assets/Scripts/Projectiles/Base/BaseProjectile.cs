using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour, IProjectile
{
    private Vector3 direction;
    private float currentLifetime;
    private bool isInitialized = false;
    
    private ProjectileConfig config;

    protected ProjectileConfig Config
    {
        get
        {
            if (config == null)
            {
                config = GetConfig();
            }
            return config;
        }
    }
    
    protected abstract ProjectileConfig GetConfig();
    public int Damage => Config.Damage;
    public float Speed => Config.Speed;
    public string PoolName => Config.PoolName;
    
    void Update()
    {
        if (!isInitialized) return;
        
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= Config.Lifetime || transform.position.y < 0)
        {
            DestroyProjectile();
            return;
        }
        
        MoveProjectile();
    }
    
    public virtual void Initialize(Vector3 dir)
    {
        direction = dir.normalized;
        currentLifetime = 0f;
        isInitialized = true;
    }
    
    protected virtual void MoveProjectile()
    {
        Vector3 translation = direction * Speed;
        transform.Translate(translation * Time.deltaTime, Space.World);
    }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        var targetable = other.GetComponent<ITargetable>();
        if (targetable != null)
        {
            OnHit(targetable);
        }
    }
    
    public virtual void OnHit(ITargetable target)
    {
        if (target != null && target.IsAlive)
        {
            target.TakeDamage(Damage);
            GameEvents.InvokeProjectileHit(this);
        }
        
        DestroyProjectile();
    }
    
    protected virtual void DestroyProjectile() 
    { 
        PoolManager.Instance.ReturnProjectileToPool(PoolName, this);
    }
} 