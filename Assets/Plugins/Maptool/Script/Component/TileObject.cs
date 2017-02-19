using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool.Component
{
    public class TileObject : MonoBehaviour
    {
        #region Public Feild
        public UISprite sprite = null;
        public UIButton button = null;
        #endregion Public Feild

        #region Public Property

        public Tile       TileInfo { get; private set; }
        public int        Index    { get; set; }
        public Vector2    Position { get; private set; }
        public GameObject Parent   { get; private set; }

        #endregion Public Property

        #region Public Methods

        public void Init(GameObject _parent, int _idx)
        {
            TileInfo = new Tile();
            Index = _idx;
            SetPosition(_idx);
            SetParent(_parent);
        }

        public void OnClick()
        {
            var scale = sprite.transform.localScale;
            TileInfo = MaptoolManager.Instance.CurrentTile;

            sprite.spriteName = TileInfo.Name;
            sprite.transform.localRotation = TileManager.GetRotation(TileInfo.Rotaion);
            sprite.transform.localScale = TileManager.GetReverse(scale, TileInfo.Reverse);

            button.normalSprite = TileInfo.Name;
        }

        public void SetPosition(int _idx)
        {
            var _mapSize = MaptoolManager.Instance.MapSize;
            int _xPos = XPositionCalculator((int)_mapSize.x, _idx);
            int _yPos = YPositionCalculator((int)_mapSize.y, _idx);

            Position = new Vector2(_xPos, _yPos);
        }

        public void SetParent(GameObject _obj)
        {
            Parent = _obj;
        }

        #endregion Public Methods

        #region Private Methods

        private int XPositionCalculator(int _ref, int _idx)
        {
            int _tmpIdx = 0;

            do
            {
                _tmpIdx = _ref - _idx;

                if (_tmpIdx <= 0)
                {
                    _idx -= _ref;
                }
            }
            while (_tmpIdx <= 0);

            return _idx;
        }

        private int YPositionCalculator(int _ref, int _idx)
        {
            try
            {
                return _idx / (int)_ref;
            }
            catch 
            {
                return 0;
            }
        }

        #endregion Private Methods
    }
}