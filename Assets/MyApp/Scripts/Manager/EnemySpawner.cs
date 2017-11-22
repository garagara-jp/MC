using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private List<GameObject> enemyPrefabs;

    private void Start()
    {
        // コルーチンを設定
        StartCoroutine(SpawnEnemy(enemySpawnInterval));
    }

    // スポーン処理
    private IEnumerator SpawnEnemy(float second)
    {
        var seed = 1;
        Random.InitState(XXHashCalculator.GetXXHash(seed));

        while (true)
        {
            while (battleManager.DoSpawn && doSpawn)
            {

                // リスト内のプレハブのランダムに返す
                var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count - 1)], transform.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(second - spawnIntervalRandomRange / 2, second + spawnIntervalRandomRange / 2));
            }
            yield return new WaitForSeconds(second);
        }
    }
}
