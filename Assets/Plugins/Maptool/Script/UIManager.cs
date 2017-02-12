using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    #region Public Field
    public Queue Children;
    #endregion Public Field

    #region Public Methods
    public void AddChildren(GameObject _obj)
    {
        Children.Enqueue(_obj);
    }
    #endregion Public Methods
}
