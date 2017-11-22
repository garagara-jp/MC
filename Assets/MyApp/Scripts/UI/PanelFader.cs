using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{
    private float alfa = 1;
    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private GameObject panel;
    private Image panelImage;
    private float red, green, blue;

    void Start()
    {
        if (!panel.activeInHierarchy)
        {
            panel.SetActive(true);
        }

        panelImage = panel.GetComponent<Image>();
        red = panelImage.color.r;
        green = panelImage.color.g;
        blue = panelImage.color.b;
    }

    void Update()
    {
        panelImage.color = new Color(red, green, blue, alfa);
        alfa -= speed;
        if (alfa <= 0)
            panel.SetActive(false);
    }
}