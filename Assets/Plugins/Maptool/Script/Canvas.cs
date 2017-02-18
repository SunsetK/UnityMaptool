using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool
{
    public class Canvas : MaptoolManager
    {
        #region Public Field

        public UIGrid     grid = null;
        public GameObject tile = null;

        #endregion Public Field

        #region Public Property

        #endregion Public Property

        #region Public Methods

        public void Start()
        {
            InitMap();
        }

        public void Update()
        {
            DrawMap();
        }

        #endregion Public Methods

        #region Private Methods

        private void InitMap()
        {
            /*
            var tileInstance = Instantiate(tile) as GameObject;
            var tileComponent = tileInstance.GetComponent<TileMenu.TileSelectButton>();

            tileComponent.SetParent(grid.gameObject);
            grid.repositionNow = true;
            tileInstance.transform.SetParent(grid.transform, false);
            */
        }

        private void DrawMap()
        {
            
        }

        #endregion Private Methods
    }
}