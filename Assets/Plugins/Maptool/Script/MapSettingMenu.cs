using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maptool
{
    public class MapSettingMenu : WindowManager
    {
        #region Public Field

        public UILabel xLebel = null;
        public UILabel yLabel = null;
        public UILabel layer  = null;

        #endregion Public Field

        #region Public Property

        public Vector2 MapSize      { get; private set; }
        public  int    CurrentLayer { get; set; }

        #endregion Public Property

        #region Public Methods

        public void Start()
        {
            MapSize = new Vector2(20, 20);
            WindowInit();
        }

        public void SetX()
        {
            MapSize = new Vector2(Convert.ToInt32(xLebel.text), MapSize.y);
        }

        public void SetY()
        {
            MapSize = new Vector2(MapSize.x, Convert.ToInt32(yLabel.text));
        }

        public void RefreshMapSize()
        {
            MaptoolManager.SetMapSize(MapSize);
        }

        public void LeftButton()
        {
            if (CurrentLayer > 0)
            {
                CurrentLayer -= 1;
            }

            layer.text = CurrentLayer.ToString("D2");
            MaptoolManager.SetLayer(CurrentLayer);
        }

        public void RightButton()
        {
            if (CurrentLayer < 100)
            {
                CurrentLayer += 1;
            }

            layer.text = CurrentLayer.ToString("D2");
            MaptoolManager.SetLayer(CurrentLayer);
        }

        #endregion Public Methods
    }
}
