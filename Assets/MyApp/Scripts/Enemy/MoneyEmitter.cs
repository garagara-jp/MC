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

    private List<GameObject> moneyPrefabs = new List<GameObject>();
    private List<SpriteRenderer> moneySpriteRenderers = new List<SpriteRenderer>();
    private List<Rigidbody2D> moneyRb2Ds = new List<Rigidbody2D>();
    private bool moneyIsEmitted;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();

        foreach (var i in enemyStatusModel.MoneyPrefabs)
            moneyPrefabs.Add(i);

        for (int i = 0; i < moneyPrefabs.Count; i++)
        {
            moneySpriteRenderers.Add(moneyPrefabs[i].GetComponent<SpriteRenderer>());
            moneySpriteRenderers[i].enabled = false;
            moneyRb2Ds.Add(moneyPrefabs[i].GetComponent<Rigidbody2D>());
            moneyRb2Ds[i].simulated = false;
        }

        moneyIsEmitted = false;
    }

    private void Update()
    {
        if (enemyStatusModel.IsDead && !moneyIsEmitted)
        {
            for (int i = 0; i < moneyPrefabs.Count; i++)
            {
                // インターフェースからMoneyのValueをセット
                var setableMoney = moneyPrefabs[i].GetComponent<ISetableMoney>();
                if (setableMoney != null)
                {
                    var moneyValue = enemyStatusModel.EnemyMoney;
                    setableMoney.SetMoneyValue(moneyValue);
                }

                // MoneyのRendererをONに
                moneySpriteRenderers[i].enabled = true;
            }

            moneyIsEmitted = true;
        }
    }

    private void FixedUpdate()
    {
        if (moneyPrefabs != null && moneyIsEmitted)
        {
            for (int i = 0; i < moneyPrefabs.Count; i++)
            {
                moneyRb2Ds[i].simulated = true;

                // ランダムな方向に射出
                var targetVec = new Vector2((UnityEngine.Random.Range(-1, 1) >= 0) ? 1 : -1, UnityEngine.Random.Range(1, 3));
                moneyRb2Ds[i].velocity = targetVec;

                // Cloneオブジェクトをnull値に
                moneyPrefabs[i] = null;
            }

            // ModelのboolをOFFに
            enemyStatusModel.IsHaveMoney = false;
        }
    }
}