using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class UIManager : MonoBehaviour
{
    GameStatusModel gameStatusModel;
    PlayerStatusModel playerStatusModel;
    DealerStatusModel dealerStatusModel;
    TimeManager timeManager;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject dealer;

    [SerializeField]
    private Text playerGoldValue;
    [SerializeField]
    private Text limitTImeValue;

    [SerializeField]
    private GameObject tradeWindow;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        if (dealer == null)
            dealer = GameObject.FindWithTag("Dealer");

        playerStatusModel = player.GetComponent<PlayerStatusModel>();
        dealerStatusModel = dealer.GetComponent<DealerStatusModel>();
        gameStatusModel = GetComponent<GameStatusModel>();
        timeManager = GetComponent<TimeManager>();

        tradeWindow.SetActive(false);
    }

    private void Update()
    {
        // Playerの所持金と残り時間を表示
        playerGoldValue.text = "￥" + playerStatusModel.PlayerMoney.ToString();
        limitTImeValue.text = Mathf.CeilToInt(timeManager.RemainingTIme).ToString();

        // アイテムトレード画面を表示
        if (dealerStatusModel.isShowWindow)
        {
            tradeWindow.SetActive(true);
            gameStatusModel.IsPause = true;
        }
        else
        {
            tradeWindow.SetActive(false);
            gameStatusModel.IsPause = false;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 100, 100, 30), "HP : " + playerStatusModel.HitPoint.ToString());
    }
}
