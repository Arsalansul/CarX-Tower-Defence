using UnityEngine;

public class CannonProjectileParabolic : BaseProjectile
{
    private Vector3 velocity;
    
    public override void Initialize(Vector3 velocity)
    {
        this.velocity = velocity;
        
        base.Initialize(velocity);
    }

    protected override ProjectileConfig GetConfig()
    {
        return ConfigManager.Instance.GetParabolicProjectileConfig();
    }

    protected override void MoveProjectile()
    {
        velocity += Vector3.down * GameManager.Instance.Config.Gravity * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime, Space.World);
        
        transform.rotation = Quaternion.LookRotation(velocity.normalized);
    }
} 