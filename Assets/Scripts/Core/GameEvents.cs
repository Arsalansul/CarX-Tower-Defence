using UnityEngine;
using System;

public static class GameEvents
{
    public static event Action<ITargetable> OnTargetDestroyed;
    public static event Action<ITargetable> OnTargetSpawned;
    public static event Action<ITower> OnTowerShoot;
    public static event Action<IProjectile> OnProjectileHit;
    
    public static void InvokeTargetDestroyed(ITargetable target)
    {
        OnTargetDestroyed?.Invoke(target);
    }
    
    public static void InvokeTargetSpawned(ITargetable target)
    {
        OnTargetSpawned?.Invoke(target);
    }
    
    public static void InvokeTowerShoot(ITower tower)
    {
        OnTowerShoot?.Invoke(tower);
    }
    
    public static void InvokeProjectileHit(IProjectile projectile)
    {
        OnProjectileHit?.Invoke(projectile);
    }
} 