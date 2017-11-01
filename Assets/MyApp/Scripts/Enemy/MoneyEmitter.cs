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

    [SerializeField]
    private GameObject moneyPrefab;
    private SpriteRenderer moneySpriteRenderer;
    private Rigidbody2D moneyRb2D;
    private bool moneyIsEmitted;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();

        if (moneyPrefab == null)
            moneyPrefab = GameObject.FindWithTag("Money");
        if (moneyPrefab != null)
        {
            moneySpriteRenderer = moneyPrefab.GetComponent<SpriteRenderer>();
            moneySpriteRenderer.enabled = false;
            moneyRb2D = moneyPrefab.GetComponent<Rigidbody2D>();
            moneyRb2D.simulated = false;
        }

        moneyIsEmitted = false;
    }

    private void Update()
    {
        if (enemyStatusModel.IsDead && !moneyIsEmitted)
        {
            // インターフェースからMoneyのValueをセット
            var haveMoney = moneyPrefab.GetComponent<IHaveMoney>();
            if (haveMoney != null)
            {
                var moneyValue = enemyStatusModel.EnemyMoney;
                haveMoney.SetMoneyValue(moneyValue);
            }

            // MoneyのRendererをONに
            moneySpriteRenderer.enabled = true;
            
            moneyIsEmitted = true;
        }
    }

    private void FixedUpdate()
    {
        if (moneyPrefab != null && moneyIsEmitted)
        {
            moneyRb2D.simulated = true;

            // ランダムな方向に射出
            var targetVec = new Vector2((UnityEngine.Random.Range(-1, 1) >= 0) ? 1 : -1, UnityEngine.Random.Range(1, 3));
            moneyRb2D.velocity = targetVec;

            // Cloneオブジェクトをnull値に
            moneyPrefab = null;

            // ModelのboolをOFFに
            enemyStatusModel.IsHaveMoney = false;
        }
    }
}