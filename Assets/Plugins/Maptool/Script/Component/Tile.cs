using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool.Component
{
    public class Tile
    {
        #region Public Field
        // ...
        #endregion Public Field

        #region Public Property

        public int                   Number  { get; set; }
        public string                Name    { get; set; }
        public TileManager.TYPE      Type    { get; set; }
        public TileManager.ROTATION  Rotaion { get; set; }
        public TileManager.REVERS    Reverse { get; set; }

        #endregion Public Property


        #region Public Methods

        public Tile()
        {
            Number = 0;
            Type = TileManager.TYPE.EMPTY;
            Reverse = TileManager.REVERS.DEFAULT;
            Rotaion = TileManager.ROTATION.DEFAULT;
            Name = TileManager.GetTileName(Type, Number);
        }

        public void Init(Tile _tile)
        {
            Number  = _tile.Number;
            Name    = _tile.Name;
            Type    = _tile.Type;
            Rotaion = _tile.Rotaion;
            Reverse = _tile.Reverse;
        }

        public void Init(TileManager.TYPE _type, int _num)
        {
            Number  = _num;
            Type    = _type;
            Reverse = TileManager.REVERS.DEFAULT;
            Rotaion = TileManager.ROTATION.DEFAULT;
            Name = TileManager.GetTileName(Type, Number);
        }

        public void RotateTile()
        {
            switch (Rotaion)
            {
                case TileManager.ROTATION.DEFAULT:
                    Rotaion = TileManager.ROTATION.ROT90;
                    break;
                case TileManager.ROTATION.ROT90:
                    Rotaion = TileManager.ROTATION.ROT180;
                    break;
                case TileManager.ROTATION.ROT180:
                    Rotaion = TileManager.ROTATION.ROT270;
                    break;
                case TileManager.ROTATION.ROT270:
                    Rotaion = TileManager.ROTATION.DEFAULT;
                    break;
            }
        }

        public void ReverseTile()
        {
            switch (Reverse)
            {
                case TileManager.REVERS.DEFAULT:
                    Reverse = TileManager.REVERS.REVERS;
                    break;
                case TileManager.REVERS.REVERS:
                    Reverse = TileManager.REVERS.DEFAULT;
                    break;
            }
        }

        #endregion Public Methods
    }
}

