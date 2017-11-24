using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各EnemySpawnオブジェクトにアタッチ
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    BattleManager battleManager;
    [SerializeField]
    private float enemySpawnInterval = 1;
    [SerializeField]
    private float spawnIntervalRandomRange = 1;
    [SerializeField]
    private bool doSpawn = true;
    [SerializeField]
    private bool isUsingConstSeed = false;
    [SerializeField]
    private int constSeed = 1;

    [SerializeField]
    private List<GameObject> enemyPrefabs;

    private void Start()
    {
        // コルーチンを設定
        StartCoroutine(SpawnEnemy(enemySpawnInterval));
    }

    // スポーン処理
    private IEnumerator SpawnEnemy(float second)
    {
        var seed = (isUsingConstSeed) ? constSeed : Environment.TickCount;
        UnityEngine.Random.InitState(XXHashCalculator.GetXXHash(seed));

        while (true)
        {
            while (battleManager.DoSpawn && doSpawn)
            {
                // リスト内のプレハブのランダムに返す
                yield return new WaitForSeconds(UnityEngine.Random.Range(second - spawnIntervalRandomRange / 2, second + spawnIntervalRandomRange / 2));
                var enemy = Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count - 1)], transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(second);
        }
    }
}
