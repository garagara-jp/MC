using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moneyにアタッチ
/// </summary>
public class MoneyLocomotor : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    private float fallSpeed = 0.1f;
    [SerializeField]
    private float maxFallSpeed = 1f;
    private bool isGrounded = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            if (rb2D.velocity.y >= -maxFallSpeed)
                rb2D.velocity += Vector2.down * fallSpeed;
            else
                rb2D.velocity = Vector2.down * maxFallSpeed;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Stage")
            isGrounded = true;
    }
}
