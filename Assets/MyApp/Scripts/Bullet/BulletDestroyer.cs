using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletにアタッチ
/// BulletオブジェクトのDestroy処理
/// </summary>
public class BulletDestroyer : MonoBehaviour
{
    BulletStatusModel model;

    private void Start()
    {
        model = GetComponent<BulletStatusModel>();
    }

    private void Update()
    {
        if (model.IsDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (model == null)
            return;

        if (col.gameObject.tag == "Stage" || col.gameObject.tag == "Enemy")
        {
            model.IsDestroyed = true;
        }
    }
}
