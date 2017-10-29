using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    PlayerWeaponModel playerWeaponModel;
    private float elapsedTime;

    private void Start()
    {
        playerWeaponModel = GetComponent<PlayerWeaponModel>();
        elapsedTime = 0f;
    }

    private void FixedUpdate()
    {

        // 攻撃処理
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotBullet(playerWeaponModel.AttackInterval, playerWeaponModel.BulletPrefab, playerWeaponModel.BulletPower, playerWeaponModel.BulletSpeed);
        }
        else
        {
            elapsedTime = 0f;
        }
    }

    private void ShotBullet(float attackInterval, GameObject bulletPrefab, float bulletPower, float bulletSpeed)
    {
        elapsedTime -= Time.fixedDeltaTime;
        if (elapsedTime <= 0.0f)
        {
            elapsedTime = attackInterval;

            // bulletを生成
            var bulletPos = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2), transform.position.z);
            var bulletRota = transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);

            // bulletのstatusを設定
            bullet.GetComponent<BulletStatusModel>().BulletPower = bulletPower;

            // 射出
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity += Vector2.up * bulletSpeed;
        }
    }
}
