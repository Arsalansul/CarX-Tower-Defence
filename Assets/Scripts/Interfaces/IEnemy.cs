using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Initialize(Queue<Vector3> target);
    HealthComponent HealthComponent { get; }
    MovementComponent MovementComponent { get; }
    string PoolName { get; }
}