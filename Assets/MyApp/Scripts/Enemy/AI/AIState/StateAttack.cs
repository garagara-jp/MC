using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 攻撃
/// </summary>
public class StateAttack : StateBase
{
    EnemyAttackModel attackModel;
    StateMachine stateMachine;
    [SerializeField]
    private GameObject player;
    private float elapsedTime;

    public override void Enter()
    {
        attackModel = GetComponent<EnemyAttackModel>();
        stateMachine = GetComponent<StateMachine>();
        if (player == null)
            player = GameObject.FindWithTag("Player");

        //Debug.Log("Attackステートに遷移しました");
    }

    public override void FixedExecute()
    {
        ShotBullet(attackModel.AttackInterval,
            attackModel.BulletPrefab,
            attackModel.BulletPower,
            gameObject.tag,
            attackModel.BulletSpeed);
    }

    private void ShotBullet(float attackInterval, GameObject bulletPrefab, float bulletPower, string myTagName, float bulletSpeed)
    {
        elapsedTime -= Time.fixedDeltaTime;
        if (elapsedTime <= 0.0f)
        {
            elapsedTime = Random.Range(attackModel.AttackInterval - 0.4f, attackModel.AttackInterval + 0.4f);

            // bulletを生成
            var bulletPos = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
            var bulletRota = bulletPrefab.transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);

            // bulletのstatusを設定
            var bulletModel = bullet.GetComponent<BulletStatusModel>();
            bulletModel.BulletPower = attackModel.BulletPower;
            bulletModel.ShootOwnerTagName = myTagName;

            // プレイヤーに向けて射出
            var targetVec = Vector3.Normalize(player.transform.position - transform.position) * bulletSpeed;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity += new Vector2(targetVec.x, targetVec.y);
        }
    }
}
