using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private List<ITargetable> activeTargets = new List<ITargetable>();
    private List<ITower> activeTowers = new List<ITower>();

    private GameConfig config;

    public GameConfig Config
    {
        get
        {
            if (config == null)
            {
                config = ConfigManager.Instance.GetGameConfig();
            }
            return config;
        }
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void RegisterTarget(ITargetable target)
    {
        if (!activeTargets.Contains(target))
        {
            activeTargets.Add(target);
            GameEvents.InvokeTargetSpawned(target);
        }
    }
    
    public void UnregisterTarget(ITargetable target)
    {
        if (activeTargets.Contains(target))
        {
            activeTargets.Remove(target);
            GameEvents.InvokeTargetDestroyed(target);
        }
    }
    
    public void RegisterTower(ITower tower)
    {
        if (!activeTowers.Contains(tower))
        {
            activeTowers.Add(tower);
        }
    }
    
    public void UnregisterTower(ITower tower)
    {
        if (activeTowers.Contains(tower))
        {
            activeTowers.Remove(tower);
        }
    }
    
    public List<ITargetable> GetTargetsInRange(Vector3 position, float range)
    {
        List<ITargetable> targetsInRange = new List<ITargetable>();
        
        foreach (var target in activeTargets)
        {
            if (target.IsAlive && Vector3.Distance(position, target.Position) <= range)
            {
                targetsInRange.Add(target);
            }
        }
        
        return targetsInRange;
    }
    
    public ITargetable GetClosestTarget(Vector3 position, float range)
    {
        ITargetable closestTarget = null;
        float closestDistance = float.MaxValue;
        
        foreach (var target in activeTargets)
        {
            if (!target.IsAlive) continue;
            
            float distance = Vector3.Distance(position, target.Position);
            if (distance <= range && distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }
        }
        
        return closestTarget;
    }
} 