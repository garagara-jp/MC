using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeButtonController : MonoBehaviour
{
    Button btn;

    //どんな名前でもいいのでstring型のフィールドに付ける
    [SerializeField]
    string nextScene;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickFunction);
    }

    void OnClickFunction()
    {
        SceneManager.LoadScene(nextScene);
    }
}