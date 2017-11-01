using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Moneyにアタッチ
/// </summary>
public class MoneyValueSetter : MonoBehaviour, IHaveMoney
{
    MoneyStatusModel moneyStatusModel;

    private void Start()
    {
        moneyStatusModel = GetComponent<MoneyStatusModel>();
    }

    public void SetMoneyValue(float moneyValue)
    {
        moneyStatusModel.MoneyValue = moneyValue;
        transform.parent = null;
    }
}
