using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotor : MonoBehaviour
{
    PlayerStatusModel model;
    Rigidbody2D rb2d;
    private Dictionary<string, int> moveDirection = new Dictionary<string, int>();

    private bool isknocking = false;
    private bool rotationTrigger = false;
    private int rotationDir;
    [SerializeField]
    LayerMask mask;

    void Start()
    {
        model = GetComponent<PlayerStatusModel>();
        rb2d = GetComponent<Rigidbody2D>();
        moveDirection.Add("left", -1);
        moveDirection.Add("right", 1);
        moveDirection.Add("pause", 0);
    }

    void Update()
    {
        // 回転処理
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotationTrigger = true;
            rotationDir = moveDirection["right"];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotationTrigger = true;
            rotationDir = moveDirection["left"];
        }
        if (rotationTrigger)
        {
            RotateAroundUpAxis(rotationDir);
        }

        //　移動処理
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveDirection["right"] * model.MoveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveDirection["left"] * model.MoveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
    }

    private void FixedUpdate()
    {
        // ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpMove();
        }
    }

    private void JumpMove()
    {
        // Rayで設置判定を取得
        float rayDis = 3.5f;
        if (Physics2D.Raycast(transform.position, -Vector3.up, transform.localScale.y * rayDis, mask))
        {
            rb2d.AddForce(Vector2.up * model.JumpPower);
        }
        //Debug.DrawRay(transform.position, -Vector3.up * transform.localScale.y * rayDis, Color.red, 2, false);
    }

    private void RotateAroundUpAxis(int dir)
    {
        var targetRotation = Quaternion.Euler(0, 90 + dir * 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * model.RotationSpeed);

        // 回転がだいたい終わったらTriggerをOFFにして角度を固定
        if (Mathf.Approximately(Quaternion.Angle(transform.rotation, targetRotation), 0f))
        {
            transform.rotation = targetRotation;
            rotationTrigger = false;
        }
    }
}
