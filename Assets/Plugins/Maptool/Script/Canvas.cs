using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool
{
    public class Canvas : MonoBehaviour
    {
        #region Public Field

        public UIGrid           grid  = null;
        public GameObject       tile  = null;
        public Queue<GameObject> tiles = new Queue<GameObject>();

        #endregion Public Field

        #region Public Property

        #endregion Public Property

        #region Public Methods

        public void Start()
        {
            InitMap();
        }

        public void RefreshMap()
        {
            int _mapSizeNumber = MaptoolManager.Instance.GetTileNumber();
            grid.GetComponent<UIGrid>().maxPerLine = (int)MaptoolManager.Instance.MapSize.x;

            if (tiles.Count < _mapSizeNumber)
            {
                int refCount = _mapSizeNumber - tiles.Count;

                for (int i = 0; i < refCount; i++)
                {
                    AddTileObject(i);
                }
            }
            else if (tiles.Count > _mapSizeNumber)
            {
                int refCount = tiles.Count - _mapSizeNumber;

                for (int i = 0; i < refCount; i++)
                {
                    var obj = tiles.Dequeue();
                    Destroy(obj.gameObject);
                }
            }

            grid.repositionNow = true;
        }

        #endregion Public Methods

        #region Private Methods

        private void InitMap()
        {
            int _tileNumber = MaptoolManager.Instance.GetTileNumber();
            grid.GetComponent<UIGrid>().maxPerLine = (int)MaptoolManager.Instance.MapSize.x;

            for (int i = 0; i < _tileNumber; i++)
            {
                AddTileObject(i);
            }
        }

        private void AddTileObject(int _idx)
        {
            var tileInstance = Instantiate(tile) as GameObject;
            var tileComponent = tileInstance.GetComponent<Component.TileObject>();

            tileComponent.Init(this.gameObject, _idx);

            grid.repositionNow = true;
            tileInstance.transform.SetParent(grid.transform, false);
            tiles.Enqueue(tileInstance.gameObject);
        }

        #endregion Private Methods
    }
}