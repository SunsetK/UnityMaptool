using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maptool.Component;

namespace Maptool
{
    public class MaptoolManager : MonoBehaviour
    {
        #region Public Property

        public static int            CurrentLayer { get; private set; }
        public static Vector2        MapSize      { get; private set; }
        public static Tile           CurrentTile  { get; private set; }

        #endregion Public Property

        #region Public Methods

        public static void SetMapSize(Vector2 _size)
        {
            MapSize = _size;
        }

        public static void SetLayer(int _layer)
        {
            CurrentLayer = _layer;
        }

        public static void SetTile(Tile _tile)
        {
            CurrentTile = _tile;
        }

        #endregion Public Methods
    }
}
