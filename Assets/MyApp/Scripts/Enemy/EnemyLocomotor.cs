using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotor : MonoBehaviour
{
    EnemyStatusModel model;

    private Vector2 startVec;
    private float angle = 0f;
    [SerializeField]
    private float upDownRange = 3f;
    [SerializeField]
    private float Yspeed = 3f;
    [SerializeField]
    private float Xspeed = 2f;

    private void Start()
    {
        model = GetComponent<EnemyStatusModel>();
        angle = (model.EnemyType == EnemyType.Flow) ? 90 : 0;
    }

    void Update()
    {
        if (model.EnemyType == EnemyType.Flow)
        {
            Vector2 newVec = transform.position;
            //angle = angle % 360;     // sin計算用にアングルを調整
            newVec.y = Mathf.Sin(angle * Mathf.Deg2Rad) * upDownRange * Time.deltaTime + newVec.y;
            angle += Yspeed;
            if (angle > 450)
                angle = 90;
            newVec.x += Xspeed * Time.deltaTime;
            transform.position = newVec;
        }
        else if (model.EnemyType == EnemyType.Ground)
        {
            Vector2 newVec = transform.position;
            //angle = angle % 180;     // sin計算用にアングルを調整
            newVec.y = Mathf.Cos(angle * Mathf.Deg2Rad) * upDownRange * Time.deltaTime + newVec.y;
            angle += Yspeed;
            if (angle > 180)
                angle = 0;
            newVec.x += Xspeed * Time.deltaTime;
            transform.position = newVec;
        }
    }
}
