using UnityEngine;

public class GuidedProjectile : BaseProjectile
{
    private ITargetable target;
    
    public void SetTarget(ITargetable newTarget)
    {
        target = newTarget;
    }

    protected override ProjectileConfig GetConfig()
    {
        return ConfigManager.Instance.GetGuidedProjectileConfig();
    }

    protected override void MoveProjectile()
    {
        if (target == null || !target.IsAlive)
        {
            DestroyProjectile();
            return;
        }
        
        var direction = (target.Position - transform.position).normalized;
        
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }
} 