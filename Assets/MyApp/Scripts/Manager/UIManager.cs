using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerStatusModel playerStatusModel;
    DealerStatusModel dealerStatusModel;
    TimeManager timeManager;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject dealer;

    [SerializeField]
    Text playerGoldValue;
    [SerializeField]
    Text limitTImeValue;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        if (dealer == null)
            dealer = GameObject.FindWithTag("Dealer");

        playerStatusModel = player.GetComponent<PlayerStatusModel>();
        dealerStatusModel = dealer.GetComponent<DealerStatusModel>();
        timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        playerGoldValue.text = "￥" + playerStatusModel.PlayerMoney.ToString();
        limitTImeValue.text = Mathf.CeilToInt(timeManager.RemainingTIme).ToString();

        if (dealerStatusModel.isShowWindow)
        {

        }
    }
}
