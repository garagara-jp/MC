using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletにアタッチ
/// BulletオブジェクトのDestroy処理
/// </summary>
public class BulletDestroyer : MonoBehaviour
{
    BulletStatusModel bulletStatusModel;

    private void Start()
    {
        bulletStatusModel = GetComponent<BulletStatusModel>();
    }

    private void Update()
    {
        if (bulletStatusModel.IsDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Stage")
        {
            bulletStatusModel.IsDestroyed = true;
        }
    }
}
