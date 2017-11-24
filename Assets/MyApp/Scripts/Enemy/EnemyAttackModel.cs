using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackModel : MonoBehaviour
{
    [SerializeField]
    private int weaponID = 1;
    [SerializeField]
    private GameObject bulletPrafab;
    [SerializeField]
    private float bulletPower = 10f;
    [SerializeField]
    private float bulletSpeed = 3f;
    [SerializeField,Range(0,10)]
    private float attackInterval = 0.3f;

    public int WeaponID { get; set; }
    public GameObject BulletPrefab { get; set; }
    public float BulletPower { get; set; }
    public float BulletSpeed { get; set; }
    public float AttackInterval { get; set; }

    private void Start()
    {
        // 初期化処理
        WeaponModelInitialization();
    }

    private void WeaponModelInitialization()
    {
        WeaponID = weaponID;
        BulletPrefab = bulletPrafab;
        BulletPower = bulletPower;
        AttackInterval = attackInterval;
        BulletSpeed = bulletSpeed;
    }
}