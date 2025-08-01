using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }
    
    [Header("Configuration Files")]
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private TowerConfig cannonTowerConfig;
    [SerializeField] private TowerConfig simpleTowerConfig;
    [SerializeField] private ProjectileConfig cannonProjectileConfig;
    [SerializeField] private ProjectileConfig guidedProjectileConfig;
    [SerializeField] private ProjectileConfig parabolicProjectileConfig;
    [SerializeField] private EnemyConfig monsterConfig;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadDefaultConfigs();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void LoadDefaultConfigs()
    {
        if (gameConfig == null)
            gameConfig = Resources.Load<GameConfig>("Configs/GameConfig");
        
        if (cannonTowerConfig == null)
            cannonTowerConfig = Resources.Load<TowerConfig>("Configs/CannonTowerConfig");
        
        if (simpleTowerConfig == null)
            simpleTowerConfig = Resources.Load<TowerConfig>("Configs/SimpleTowerConfig");
        
        if (cannonProjectileConfig == null)
            cannonProjectileConfig = Resources.Load<ProjectileConfig>("Configs/CannonProjectileConfig");
        
        if (guidedProjectileConfig == null)
            guidedProjectileConfig = Resources.Load<ProjectileConfig>("Configs/GuidedProjectileConfig");
        
        if (parabolicProjectileConfig == null)
            parabolicProjectileConfig = Resources.Load<ProjectileConfig>("Configs/ParabolicProjectileConfig");
        
        if (monsterConfig == null)
            monsterConfig = Resources.Load<EnemyConfig>("Configs/MonsterConfig");
    }
    
    public GameConfig GetGameConfig() => gameConfig;
    public TowerConfig GetCannonTowerConfig() => cannonTowerConfig;
    public TowerConfig GetSimpleTowerConfig() => simpleTowerConfig;
    public ProjectileConfig GetCannonProjectileConfig() => cannonProjectileConfig;
    public ProjectileConfig GetGuidedProjectileConfig() => guidedProjectileConfig;
    public ProjectileConfig GetParabolicProjectileConfig() => parabolicProjectileConfig;
    public EnemyConfig GetMonsterConfig() => monsterConfig;
} 