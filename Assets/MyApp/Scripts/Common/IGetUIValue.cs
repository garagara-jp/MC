using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Getされる側に実装
/// </summary>
public interface IGetUIValue<T>
{
    T GetUIValue();
}
