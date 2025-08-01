using UnityEngine;

public class CannonTower : BaseTower
{
    private bool isTargetAcquired = false;
    protected override TowerConfig GetConfig()
    {
        return ConfigManager.Instance.GetCannonTowerConfig();
    }
    
    protected override void Shoot()
    {
        if (!isTargetAcquired) return;
        
        projectilePoolName = Config.UseParabolicTrajectory ? Config.ParabolicProjectilePrefab.PoolName : Config.ProjectilePrefab.PoolName;
        
        base.Shoot();
    }
    
    public override void UpdateTargeting()
    {
        base.UpdateTargeting();
        
        if (HasTarget && turret != null)
        {
            RotateTurretTowardsTarget();
        }
    }

    protected override void InitializeProjectile()
    {
        Vector3 leadPosition;
        Vector3 direction;
        currentProjectile.transform.position = shootPoint.position;
        currentProjectile.transform.rotation = shootPoint.rotation;

        if (Config.UseParabolicTrajectory)
        {
            leadPosition = TargetingSystem.CalculateParabolicLeadPosition(
                shootPoint.position,
                currentTarget.Position,
                currentTarget.Velocity,
                GameManager.Instance.Config.Gravity);
            var timeToTarget = TargetingSystem.CalculateParabolicTimeToTarget(shootPoint.position, leadPosition, GameManager.Instance.Config.Gravity);
            var projectileSpeed = TargetingSystem.CalculateParabolicProjectileSpeed(shootPoint.position, leadPosition, timeToTarget);
            direction = leadPosition - shootPoint.position;
            direction.y = 0;
            ((CannonProjectileParabolic)currentProjectile).Initialize(direction.normalized * projectileSpeed);
            return;
        }
        
        leadPosition = TargetingSystem.CalculateLeadPosition(
                shootPoint.position,
                currentTarget.Position,
                currentTarget.Velocity,
                Config.ProjectilePrefab.Speed);
        direction = (leadPosition - shootPoint.position).normalized;
        currentProjectile.Initialize(direction);
    }
    
    private void RotateTurretTowardsTarget()
    {
        var targetRotation = Config.UseParabolicTrajectory ? 
            TargetingSystem.CalculateParabolicAimRotationWithLead(
                shootPoint.position,
                currentTarget.Position,
                currentTarget.Velocity,
                GameManager.Instance.Config.Gravity) :
            TargetingSystem.CalculateAimRotationWithLead(
                shootPoint.position,
                currentTarget.Position,
                currentTarget.Velocity,
                Config.ProjectilePrefab.Speed);
        targetRotation.x = 0;
        targetRotation.z = 0;
        turret.rotation = Quaternion.RotateTowards(turret.rotation, targetRotation, Config.RotationSpeed * Time.deltaTime);
        
        isTargetAcquired = Mathf.Abs(Quaternion.Dot(shootPoint.rotation.normalized, targetRotation.normalized)) >= 0.99f;
    }
} 