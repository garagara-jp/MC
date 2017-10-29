using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 攻撃
/// </summary>
public class StateAttack : StateBase
{
    [SerializeField]
    StateMachine stateMachine;
    [SerializeField]
    StateWander stateWander;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float rotationSmooth = 1f;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float attackInterval = 2f;
    private float lastAttackTime;
    [SerializeField]
    private float margin = 50f;
    [SerializeField]
    GameObject bulletPrefab;
    GameObject bulletClone;
    [SerializeField]
    GameObject muzzle;
    [SerializeField]
    private float bulletSpeed = 250f;
    [SerializeField]
    private float pursuitSqrDistance = 2500f;

    public override void Enter()
    {
        //Debug.Log("Attackステートに遷移しました");
    }

    public override void Execute()
    {
        // プレイヤーとの距離を計算
        float sqrDistanceToPlayer = Vector3.SqrMagnitude(transform.position - player.transform.position);

        // プレイヤーの方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        // 前方に進む
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // 一定間隔で弾丸を発射する
        if (Time.time > lastAttackTime + Random.Range(attackInterval, attackInterval + 0.5f))
        {
            bulletClone = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            lastAttackTime = Time.time;
        }

        // プレイヤーとの距離が大きければ、徘徊ステートに遷移
        if (sqrDistanceToPlayer > pursuitSqrDistance + margin)
        {
            stateMachine.ChangeState(stateWander);
        }
    }

    public override void FixedExecute()
    {
        if (bulletClone != null)
        {
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.velocity = bulletClone.transform.forward * bulletSpeed;
        }
    }

    public override void Exit() { }
}
