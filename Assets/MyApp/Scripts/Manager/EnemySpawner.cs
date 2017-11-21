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
    private List<GameObject> enemyPrefabs;

    private void Start()
    {
        // コルーチンを設定
        StartCoroutine(SpawnEnemy(battleManager.EnemySpawnInterval));
    }

    // スポーン処理
    private IEnumerator SpawnEnemy(float second)
    {
        while (true)
        {
            while (battleManager.DoSpawn)
            {
                // リスト内のプレハブのランダムに返す
                var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count - 1)], transform.position, transform.rotation);
                yield return new WaitForSeconds(second);
            }
            yield return new WaitForSeconds(second);
        }
    }
}
