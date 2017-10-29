using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusModel : MonoBehaviour
{
    [SerializeField]
    private float hitPoint = 100f;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float jumpPower = 400f;
    [SerializeField]
    private float playerMoney = 0;

    public float HitPoint { get; set; }
    public float MoveSpeed { get; set; }
    public float RotationSpeed { get; set; }
    public float JumpPower { get; set; }
    public float PlayerMoney { get; set; }

    private void Start()
    {
        // Statusの初期化処理
        PlayerStatusInitialization();
    }

    public void PlayerStatusInitialization()
    {
        HitPoint = hitPoint;
        MoveSpeed = moveSpeed;
        RotationSpeed = rotationSpeed;
        JumpPower = jumpPower;
        PlayerMoney = playerMoney;
    }
}
