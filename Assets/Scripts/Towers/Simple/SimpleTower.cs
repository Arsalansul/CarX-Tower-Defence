public class SimpleTower : BaseTower
{
    protected override TowerConfig GetConfig()
    {
        return ConfigManager.Instance.GetSimpleTowerConfig();
    }

    protected override void Shoot()
    {
        base.Shoot();
        
        var guidedProjectile = (GuidedProjectile) currentProjectile;
        guidedProjectile.SetTarget(currentTarget);
    }
} 