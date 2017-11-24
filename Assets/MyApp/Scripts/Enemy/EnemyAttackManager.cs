using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 攻撃
/// </summary>
public class EnemyAttackManager : StateBase
{
    EnemyAttackModel model;
    [SerializeField]
    private GameObject player;
    private float elapsedTime;

    public void Start()
    {
        model = GetComponent<EnemyAttackModel>();
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
    }

    public void FixedUpdate()
    {
        if (player != null)
        {
            ShotBullet(model.AttackInterval,
                model.BulletPrefab,
                model.BulletPower,
                gameObject.tag,
                model.BulletSpeed);
        }
    }

    private void ShotBullet(float attackInterval, GameObject bulletPrefab, float bulletPower, string myTagName, float bulletSpeed)
    {
        elapsedTime -= Time.fixedDeltaTime;
        if (elapsedTime <= 0.0f)
        {
            elapsedTime = Random.Range(model.AttackInterval - 0.4f, model.AttackInterval + 0.4f);

            // bulletを生成
            var bulletPos = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
            var bulletRota = bulletPrefab.transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);

            // bulletのstatusを設定
            var bulletModel = bullet.GetComponent<BulletStatusModel>();
            bulletModel.BulletPower = model.BulletPower;

            // プレイヤーに向けて射出
            var targetVec = Vector3.Normalize(player.transform.position - transform.position) * bulletSpeed;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity += new Vector2(targetVec.x, targetVec.y);
        }
    }
}
