using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotor : MonoBehaviour
{
    EnemyStatusModel model;

    private Vector2 startVec;
    private float angle = 0f;
    [SerializeField]
    private float upDownRange = 0.06f;
    [SerializeField]
    private float Yspeed = 3f;
    [SerializeField]
    private float Xspeed = 2f;

    [SerializeField]
    private float t = 0;

    private void Start()
    {
        model = GetComponent<EnemyStatusModel>();
        startVec = transform.position;
    }

    void Update()
    {
        if (model.EnemyType == EnemyType.Flow)
        {
            Vector2 newVec = transform.position;
            angle = (angle % 360 != 180) ? angle % 360 : 0;     // sin計算用にアングルを調整
            newVec.y = Mathf.Sin(angle * Mathf.Deg2Rad) * upDownRange + newVec.y;
            angle += Yspeed * Time.deltaTime;
            newVec.x += Xspeed * Time.deltaTime;
            transform.position = newVec;
        }
        else if (model.EnemyType == EnemyType.Ground)
        {
            Vector2 newVec = transform.position;
            angle = angle % 180;     // sin計算用にアングルを調整
            newVec.y = Mathf.Cos(angle * Mathf.Deg2Rad) * upDownRange + newVec.y;
            angle += Yspeed * Time.deltaTime;
            newVec.x += Xspeed * Time.deltaTime;
            transform.position = newVec;
        }
        var rt = (t % 360 != 180) ? t % 360 : 0;
    }
}
