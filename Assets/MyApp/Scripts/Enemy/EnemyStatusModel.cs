using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Flow, Ground }
public enum EnemySize { S, L }

public class EnemyStatusModel : MonoBehaviour
{
    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private EnemySize enemySize;
    [SerializeField]
    private float hitPoint = 100f;
    [SerializeField]
    private float enemyPower = 10f;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float jumpPower = 400f;
    [SerializeField]
    private float enemyMoney = 100;
    [SerializeField]
    private bool isDead = false;

    public EnemyType EnemyType { get { return enemyType; } }
    public EnemySize EnemySize { get { return enemySize; } }
    public float HitPoint { get; set; }
    public float EnemyPower { get; set; }
    public float MoveSpeed { get; set; }
    public float RotationSpeed { get; set; }
    public float JumpPower { get; set; }
    public float EnemyMoney { get; set; }
    public bool IsDead { get; set; }
    public bool IsHaveMoney { get; set; }
    public List<GameObject> MoneyPrefabs { get; set; }  // Enemyの所持するMoneyプレハブ

    public int LcoinNum { get; set; }
    public int ScoinNum { get; set; }
    public int JewelNum { get; set; }

    private void Start()
    {
        // Statusの初期化処理
        ModelInitialization();
    }

    private void Update()
    {
        if (HitPoint <= 0)
            IsDead = true;
        else
            IsDead = isDead;
    }

    public void ModelInitialization()
    {
        HitPoint = hitPoint;
        EnemyPower = enemyPower;
        MoveSpeed = moveSpeed;
        RotationSpeed = rotationSpeed;
        JumpPower = jumpPower;
        EnemyMoney = enemyMoney;
        IsDead = false;
        IsHaveMoney = true;
    }
}
