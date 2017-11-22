using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    PlayerWeaponModel model;
    private float elapsedTime;
    private Vector2 bulletPos;
    private Vector2 bulletShootVec;

    private void Start()
    {
        model = GetComponent<PlayerWeaponModel>();
        elapsedTime = 0f;
        bulletShootVec = Vector2.up;
    }

    private void Update()
    {
        // bulletの射出位置を指定
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            bulletPos = transform.position + Vector3.left * transform.localScale.x * 3f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            bulletPos = transform.position + Vector3.right * transform.localScale.x * 3f;
        }
        else bulletPos = transform.position + Vector3.up * transform.localScale.y * 2.5f;
    }

    private void FixedUpdate()
    {
        // 攻撃処理
        if (Input.GetKey(KeyCode.Z))
        {
            ShotBullet(model.AttackInterval,
                model.BulletPrefab,
                model.BulletPower,
                gameObject.tag,
                model.BulletSpeed);
        }
        else
        {
            elapsedTime = 0f;
        }
    }

    private void ShotBullet(float attackInterval, GameObject bulletPrefab, float bulletPower, string myTagName, float bulletSpeed)
    {
        elapsedTime -= Time.fixedDeltaTime;
        if (elapsedTime <= 0.0f)
        {
            elapsedTime = attackInterval;

            // bulletを生成
            var bulletRota = bulletPrefab.transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);
            bullet.transform.eulerAngles = new Vector3(0, 0, 90);

            // bulletのstatusを設定
            var model = bullet.GetComponent<BulletStatusModel>();
            model.BulletPower = bulletPower;

            // 射出
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                bulletShootVec = Vector2.left;
                bullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                bulletShootVec = Vector2.right;
                bullet.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else bulletShootVec = Vector2.up;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                bulletShootVec = Vector2.up;
                bullet.transform.eulerAngles = new Vector3(0, 0, 90);
            }

            bulletRb.velocity += bulletShootVec * bulletSpeed;
        }
    }
}
