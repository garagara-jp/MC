using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Enemyをアタッチ
/// HPが0になったEnemyからMoneyを放出
/// </summary>
public class MoneyEmitter : MonoBehaviour
{
    EnemyStatusModel enemyStatusModel;
    private bool moneyIsEmitted;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();
        moneyIsEmitted = false;
    }

    private void Update()
    {
        // Enemyの死亡とMoneyの所持状況を確認
        if (enemyStatusModel.IsDead && !moneyIsEmitted)
        {
            // Moneyの排出処理
            for (int i = 0; i < enemyStatusModel.MoneyPrefabs.Count; i++)
            {
                // インターフェース越しにMoneyのValueをセット
                var setableMoney = enemyStatusModel.MoneyPrefabs[i].GetComponent<ISetableMoney>();
                if (setableMoney != null)
                {
                    // Moneyにvalueをセット（このタイミングで親子関係を解除している）
                    var moneyValue = enemyStatusModel.EnemyMoney;
                    setableMoney.SetMoneyValue(moneyValue);
                }

                // MoneyのRendererをON
                enemyStatusModel.MoneyPrefabs[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            // 排出処理の完了を確認--->
            moneyIsEmitted = true;
        }
    }

    private void FixedUpdate()
    {
        // --->排出が完了したらプレハブの挙動を設定
        if (moneyIsEmitted)
        {
            for (int i = 0; i < enemyStatusModel.MoneyPrefabs.Count; i++)
            {
                var moneyRb2D = enemyStatusModel.MoneyPrefabs[i].GetComponent<Rigidbody2D>();

                // MoneyのRigidbody2DをON
                moneyRb2D.simulated = true;

                // Moneyをランダムな方向に射出
                var targetVec = new Vector2((UnityEngine.Random.Range(-1, 1) >= 0) ? 1 : -1, UnityEngine.Random.Range(1, 3));
                moneyRb2D.velocity = targetVec;
            }

            // 挙動設定の完了を確認
            enemyStatusModel.IsHaveMoney = false;
        }
    }
}