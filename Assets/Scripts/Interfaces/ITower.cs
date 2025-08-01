using UnityEngine;

public interface ITower
{
    float AttackRange { get; }
    float ScanRange { get; }
    void UpdateTargeting();
    bool HasTarget { get; }
    ITargetable CurrentTarget { get; }
} 