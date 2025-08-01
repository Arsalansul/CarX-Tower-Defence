using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Tower Defense/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Global Settings")]
    [SerializeField] private float gravity = 9.81f;
    
    [Header("Enemy Settings")]
    [SerializeField] private string enemyName;
    [SerializeField] private float enemySpawnInterval = 1f;
    [SerializeField] private List<Vector3> movePoints;
    
    public float Gravity => gravity;
    public string EnemyName => enemyName;
    public float EnemySpawnInterval => enemySpawnInterval;
    public List<Vector3> MovePoints => movePoints;
} 