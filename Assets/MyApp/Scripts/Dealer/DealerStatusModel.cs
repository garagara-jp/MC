using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerStatusModel : MonoBehaviour
{
    [SerializeField]
    private float dealerMoney = 0;

    public float DealerMoney { get; set; }
    public bool isShowWindow { get; set; }

    private void Start()
    {
        // Statusの初期化処理
        DealerStatusInitialization();
    }

    public void DealerStatusInitialization()
    {
        DealerMoney = dealerMoney;
        isShowWindow = false;
    }
}
