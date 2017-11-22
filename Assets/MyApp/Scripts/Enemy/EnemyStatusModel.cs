using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Flow, Ground }
public enum IsClown { Clown, Normal }
public enum EnemySize { S, L }
public enum MoneyType { Lcoin, Scoin, Jewel }

public class EnemyStatusModel : MonoBehaviour
{
    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private IsClown isClown;
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
    public IsClown IsClown { get { return isClown; } }
    public EnemySize EnemySize { get { return enemySize; } }
    public int[] EnemyAttributeList { get; set; }
    public float HitPoint { get; set; }
    public float EnemyPower { get; set; }
    public float MoveSpeed { get; set; }
    public float RotationSpeed { get; set; }
    public float JumpPower { get; set; }
    public float EnemyMoney { get; set; }
    public bool IsDead { get; set; }
    public bool IsHaveMoney { get; set; }
    public List<GameObject> MoneyPrefabs { get; set; }  // Enemyの所持するMoneyプレハブ

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
