using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedManager : MonoBehaviour
{
    PlayerStatusModel model;
    Rigidbody2D rb2d;
    private bool isMuteki = false;
    private SpriteRenderer flashRenderer;
    private Color startColor;
    [SerializeField]
    private float mutekiTime = 2f;
    [SerializeField]
    private float knockBackPower = 3;
    private bool addKockback = false;

    private void Start()
    {
        model = GetComponent<PlayerStatusModel>();
        rb2d = GetComponent<Rigidbody2D>();
        flashRenderer = GetComponent<SpriteRenderer>();
        startColor = flashRenderer.color;
    }

    private void Update()
    {
        if (model.IsDamaged)
        {
            // 無敵処理
            StartCoroutine(StartMuteki());
            // ダメージによる点滅処理
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            flashRenderer.color = new Color(1f, 1f, 1f, level);
        }
        else
        {
            flashRenderer.color = startColor;
        }
    }

    IEnumerator StartMuteki()
    {
        if (isMuteki)
            yield break;
        isMuteki = true;

        gameObject.layer = LayerName.DamagedPlayerLayer;

        yield return new WaitForSeconds(mutekiTime);

        gameObject.layer = LayerName.PlayerLayer;
        isMuteki = false;
        model.IsDamaged = false;
    }

    private void FixedUpdate()
    {
        if (model.IsDamaged)
        {
            if (!addKockback)
            {
                addKockback = true;
                // 左向きのとき
                if (transform.right.normalized.x < 0)
                    rb2d.AddForce(-1 * Vector2.right * knockBackPower);
                else
                    rb2d.AddForce(Vector2.right * knockBackPower);
            }
        }
    }
}
