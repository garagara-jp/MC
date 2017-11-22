using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager001 : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SetCurrentState(GameState.Title);
    }
}
