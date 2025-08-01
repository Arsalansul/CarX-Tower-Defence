public class CannonProjectile : BaseProjectile
{
    protected override ProjectileConfig GetConfig()
    {
        return ConfigManager.Instance.GetCannonProjectileConfig();
    }
} 