using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyStatusModel : MonoBehaviour
{
    [SerializeField]
    private float moneyValue = 10;

    public float MoneyValue { get; set; }

    private void Start()
    {
        // Statusの初期化処理
        ModelInitialization();
    }

    public void ModelInitialization()
    {
        MoneyValue = moneyValue;
    }
}
