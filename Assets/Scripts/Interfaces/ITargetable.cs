using UnityEngine;

public interface ITargetable
{
    Vector3 Position { get; }
    Vector3 Velocity { get; }
    bool IsAlive { get; }
    void TakeDamage(int damage);
} 