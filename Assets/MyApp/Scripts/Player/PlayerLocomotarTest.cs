using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotarTest : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float rotationSpeed = 1f;
    private bool rotationTrigger = false;
    private int rotationDir;
    private Dictionary<string, int> moveDirection = new Dictionary<string, int>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection.Add("left", -1);
        moveDirection.Add("right", 1);
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

        Debug.Log(rotationTrigger);

        //　移動処理
        if (Input.GetKey(KeyCode.RightArrow))
        {
            HorizontalMove(moveDirection["left"]);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            HorizontalMove(moveDirection["right"]);
        }
    }

    private void HorizontalMove(int dir)
    {
        rb.velocity = Vector2.left * dir * moveSpeed;
    }

    private void RotateAroundUpAxis(int dir)
    {
        var targetRotation = Quaternion.Euler(0, 90 + dir * 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // 回転がだいたい終わったらTriggerをOFFにして角度を固定
        if (Mathf.Approximately(Quaternion.Angle(transform.rotation, targetRotation), 0f))
        {
            transform.rotation = targetRotation;
            rotationTrigger = false;
        }
    }
}
