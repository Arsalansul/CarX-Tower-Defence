using UnityEngine;
using UnityEditor;

public static class ConfigCreator
{
    [MenuItem("Tower Defense/Create Configs/Game Config")]
    public static void CreateGameConfig()
    {
        GameConfig config = ScriptableObject.CreateInstance<GameConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/GameConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Cannon Tower Config")]
    public static void CreateCannonTowerConfig()
    {
        TowerConfig config = ScriptableObject.CreateInstance<TowerConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/CannonTowerConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Simple Tower Config")]
    public static void CreateSimpleTowerConfig()
    {
        TowerConfig config = ScriptableObject.CreateInstance<TowerConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/SimpleTowerConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Cannon Projectile Config")]
    public static void CreateCannonProjectileConfig()
    {
        ProjectileConfig config = ScriptableObject.CreateInstance<ProjectileConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/CannonProjectileConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Guided Projectile Config")]
    public static void CreateGuidedProjectileConfig()
    {
        ProjectileConfig config = ScriptableObject.CreateInstance<ProjectileConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/GuidedProjectileConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Parabolic Projectile Config")]
    public static void CreateParabolicProjectileConfig()
    {
        ProjectileConfig config = ScriptableObject.CreateInstance<ProjectileConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/ParabolicProjectileConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create Configs/Monster Config")]
    public static void CreateMonsterConfig()
    {
        EnemyConfig config = ScriptableObject.CreateInstance<EnemyConfig>();
        AssetDatabase.CreateAsset(config, "Assets/Resources/Configs/MonsterConfig.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
    
    [MenuItem("Tower Defense/Create All Configs")]
    public static void CreateAllConfigs()
    {
        CreateGameConfig();
        CreateCannonTowerConfig();
        CreateSimpleTowerConfig();
        CreateCannonProjectileConfig();
        CreateGuidedProjectileConfig();
        CreateParabolicProjectileConfig();
        CreateMonsterConfig();
        
        Debug.Log("All Tower Defense configs created successfully!");
    }
} 