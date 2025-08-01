using UnityEngine;

public interface IProjectile
{
    int Damage { get; }
    float Speed { get; }
    void Initialize(Vector3 direction);
    void OnHit(ITargetable target);
} 