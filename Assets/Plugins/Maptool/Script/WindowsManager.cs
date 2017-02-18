﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Maptool
{
    public class WindowsManager : MonoBehaviour
    {
        #region Public Field

        public static readonly int DEFAULT_LAYER = 2;
        public static readonly int TOP_LAYER = 2;

        #endregion Public Field

        #region Private Field

        private static Dictionary<GameObject, int> children = new Dictionary<GameObject,int> ();

        #endregion Private Field

        #region Public Methods

        public static void AddChildren(GameObject _obj)
        {
            children.Add(_obj, GetWindowCount());
        }

        public static void SetDepthTop(GameObject _obj)
        {
            SetDepthDefault();
            SetDepth(_obj, GetWindowCount() + TOP_LAYER);
        }

        #endregion Public Methods

        #region Private Methods

        private static void SetDepth(GameObject _obj, int _depth)
        {
            _obj.GetComponent<WindowManager>().SetDepth(_depth);
        }

        private static void SetDepthDefault()
        {
            foreach (KeyValuePair<GameObject, int> _obj in children)
            {
                SetDepth(_obj.Key, _obj.Value);
            }
        }

        private static int GetWindowCount()
        {
            return children.Count + DEFAULT_LAYER;
        }

        #endregion Private Methods
    }
}
