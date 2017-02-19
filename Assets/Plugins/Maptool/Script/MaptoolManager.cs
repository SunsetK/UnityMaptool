using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maptool.Component;

namespace Maptool
{
    public class MaptoolManager
    {
        #region Public Property
        public static MaptoolManager instance = null;
        public static MaptoolManager Instance       
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaptoolManager();
                }
                return instance;
            } 
        }

        public int            CurrentLayer   { get; private set; }
        public Vector2        MapSize        { get; private set; }
        public Tile           CurrentTile    { get; private set; }

        #endregion Public Property

        #region Public Methods

        public int GetTileNumber()
        {
            int _x = (int)MapSize.x;
            int _y = (int)MapSize.y;

            return _x * _y;
        }

        public void SetMapSize(Vector2 _size)
        {
            MapSize = _size;
        }

        public void SetLayer(int _layer)
        {
            CurrentLayer = _layer;
        }

        public void SetTile(Tile _tile)
        {
            CurrentTile = _tile;
        }

        #endregion Public Methods

        #region Private Methods

        private MaptoolManager()
        {
            CurrentLayer = 0;
            MapSize = new Vector2(5, 5);
            CurrentTile = new Tile();
        }

        #endregion Private Methods
    }
}
