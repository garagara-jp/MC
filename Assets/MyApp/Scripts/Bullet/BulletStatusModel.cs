using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatusModel : MonoBehaviour
{
    public float BulletPower { get; set; }
    public bool IsDestroyed { get; set; }

    private void Start()
    {
        ModelInitialization();
    }

    public void ModelInitialization()
    {
        IsDestroyed = false;
    }
}
