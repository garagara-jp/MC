using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    PlayerWeaponModel model;
    private float elapsedTime;
    private Vector2 bulletPos;
    private Quaternion bulletRota;
    private Vector2 bulletShootVec;
    private bool up = false;
    private bool left = false;
    private bool right = false;

    private void Start()
    {
        model = GetComponent<PlayerWeaponModel>();
        elapsedTime = 0f;
        bulletShootVec = Vector2.up;
        bulletRota = transform.rotation;
    }

    private void Update()
    {
        // 入力状態を保持
        up = Input.GetKey(KeyCode.UpArrow) ? true : false;
        left = Input.GetKey(KeyCode.LeftArrow) ? true : false;
        right = Input.GetKey(KeyCode.RightArrow) ? true : false;

        // bulletの射出位置を指定
        if (left && up) bulletPos = transform.position + new Vector3(-1, 1, 0) * transform.localScale.x * 2.7f;
        else if (left && up) bulletPos = transform.position + new Vector3(1, 1, 0) * transform.localScale.x * 2.7f;
        else if (left) bulletPos = transform.position + Vector3.left * transform.localScale.x * 3f;
        else if (right) bulletPos = transform.position + Vector3.right * transform.localScale.x * 3f;
        else if (up) bulletPos = transform.position + Vector3.up * transform.localScale.y * 2.5f;
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
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, bulletRota);

            // bulletのstatusを設定
            var model = bullet.GetComponent<BulletStatusModel>();
            model.BulletPower = bulletPower;

            // 射出
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();


            if (left)
            {
                bulletShootVec = Vector2.left;
                bullet.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else if (right)
            {
                bulletShootVec = Vector2.right;
                bullet.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (left && up)
            {
                bulletShootVec = new Vector2(-1, 1);
                bullet.transform.eulerAngles = new Vector3(0, 0, 135);
            }
            else if (right && up)
            {
                bulletShootVec = new Vector2(1, 1);
                bullet.transform.eulerAngles = new Vector3(0, 0, 45);
            }
            else if (up)
            {
                bulletShootVec = Vector2.up;
                bullet.transform.eulerAngles = new Vector3(0, 0, 90);
            }

            bulletRb.velocity += bulletShootVec * bulletSpeed;
            bulletRota = bullet.transform.rotation;
        }
    }
}
