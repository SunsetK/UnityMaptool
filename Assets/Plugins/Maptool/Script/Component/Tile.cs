using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool.Component
{
    public class Tile : MonoBehaviour
    {
        #region Public Field
        // ...
        #endregion Public Field

        #region Public Property

        public int                   Number { get; set; }
        public string                Name   { get; set; }
        public TileManager.TYPE      Type       { get; set; }
        public TileManager.ROTATION  Rotaion    { get; set; }
        public TileManager.REVERS    Reverse    { get; set; }

        #endregion Public Property


        #region Public Methods

        public void Init(TileManager.TYPE _type, int _num)
        {
            Number  = _num;
            Type    = _type;
            Reverse = TileManager.REVERS.DEFAULT;
            Rotaion = TileManager.ROTATION.DEFAULT;
            Name = TileManager.GetTileName(Type, Number);
        }

        #endregion Public Methods
    }
}

