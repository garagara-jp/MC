using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerStatusModel playerStatusModel;
    TimeManager timeManager;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text playerGoldValue;
    [SerializeField]
    Text limitTImeValue;

    private void Start()
    {
        if(player == null)
            player = GameObject.FindWithTag("Player");

        playerStatusModel = player.GetComponent<PlayerStatusModel>();
        timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        playerGoldValue.text = "￥" + playerStatusModel.PlayerMoney.ToString();
        limitTImeValue.text = Mathf.CeilToInt(timeManager.RemainingTIme).ToString();
    }
}
