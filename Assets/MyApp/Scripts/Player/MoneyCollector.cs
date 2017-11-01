using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerにアタッチ
/// フィールド上のMoneyを収集
/// </summary>
public class MoneyCollector : MonoBehaviour
{
    PlayerStatusModel playerStatusModel;

    private void Start()
    {
        playerStatusModel = GetComponent<PlayerStatusModel>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var getableMoney = col.gameObject.GetComponent<IGetableMoney>();
        if (getableMoney != null)
        {
            playerStatusModel.PlayerMoney += getableMoney.GetMoneyValue();
            Destroy(col.gameObject);
        }
    }
}
