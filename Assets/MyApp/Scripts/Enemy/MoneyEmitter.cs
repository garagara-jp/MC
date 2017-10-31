using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyをアタッチ
/// HPが0になったEnemyからMoneyを放出
/// </summary>
public class MoneyEmitter : MonoBehaviour
{
    EnemyStatusModel enemyStatusModel;

    [SerializeField]
    GameObject moneyPrefab;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();
        if (moneyPrefab == null)
            moneyPrefab = GameObject.FindWithTag("Money");
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (enemyStatusModel.IsDead)
        {
            // moneyを生成
            GameObject money = Instantiate(moneyPrefab, transform.position, transform.rotation);

            // moneyのstatusを設定
            var moneyModel = money.GetComponent<MoneyStatusModel>();
            moneyModel.MoneyValue = enemyStatusModel.EnemyMoney;

            // ランダムな方向に射出
            var targetVec = new Vector2((Random.Range(-1, 1) >= 0) ? 1 : -1, Random.Range(-1, 5));
            Rigidbody2D moneyRb = money.GetComponent<Rigidbody2D>();
            moneyRb.velocity += targetVec;
        }
    }
}
