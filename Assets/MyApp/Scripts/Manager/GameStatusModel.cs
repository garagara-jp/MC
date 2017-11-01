using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusModel : MonoBehaviour
{
    [SerializeField]
    private float limitTime = 180;
    [SerializeField]
    private float enemySpawnInterval = 1;

    public bool IsPause { get; set; }
    public bool IsGameStarted { get; set; }
    public float LimitTime { get; set; }
    public bool DoSpawn { get; set; }
    public float EnemySpawnInterval { get; set; }

    private void Awake()
    {
        LimitTime = limitTime;
        EnemySpawnInterval = enemySpawnInterval;
        IsPause = false;
        IsGameStarted = false;
        DoSpawn = false;
    }
}
