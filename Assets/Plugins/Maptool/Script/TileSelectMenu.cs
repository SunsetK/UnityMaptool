using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maptool.Component;

namespace Maptool
{
    public class TileSelectMenu : WindowManager
    {
        #region Public Field

        public UISprite         selectedSprite = null;
        public UIGrid           tileMenuGrid   = null;
        public GameObject       tileButton     = null;
        public List<GameObject> tileButtons    = new List<GameObject>();

        #endregion Public Field

        #region Public Property

        public Tile SelectedTile { get; set; }

        #endregion Public Property

        #region Public Methods

        /// <summary>
        /// Start.
        /// </summary>
        public void Start()
        {
            SelectedTile = new Tile();
            WindowInit();
            InitTileSet();
        }

        public void RotateTile()
        {
            SelectedTile.RotateTile();
            UpdatePreviewTile();
        }

        public void ReverseTile()
        {
            SelectedTile.ReverseTile();
            UpdatePreviewTile();
        }

        /// <summary>
        /// St Selected Title.
        /// </summary>
        /// <param name="_name">Tile name.</param>
        public void  SetSelectedTile(Tile _tile)
        {
            for (int i = 0; i < tileButtons.Count; i++)
            {
                tileButtons[i].GetComponent<TileMenu.TileSelectButton>().SetSelectStatus(false);
            }
            
            selectedSprite.spriteName = _tile.Name;
            SelectedTile.Init(_tile);
            UpdatePreviewTile(true);
        }

        #endregion Public Methods

        #region Private Methods

        private void UpdatePreviewTile(bool _default = false)
        {
            var scale = selectedSprite.transform.localScale;

            if (_default)
            {
                SelectedTile.Rotaion = TileManager.ROTATION.DEFAULT;
                SelectedTile.Reverse = TileManager.REVERS.DEFAULT;
            }

            selectedSprite.transform.localRotation = TileManager.GetRotation(SelectedTile.Rotaion);
            selectedSprite.transform.localScale = TileManager.GetReverse(scale, SelectedTile.Reverse);

            MaptoolManager.Instance.SetTile(SelectedTile);
        }

        /// <summary>
        /// Innitialize tile set.
        /// </summary>
        private void InitTileSet()
        {
            List<TileManager.TYPE> _tileType = new List<TileManager.TYPE>
            {
                TileManager.TYPE.EMPTY, TileManager.TYPE.GROUND, 
                TileManager.TYPE.PATH, TileManager.TYPE.WATER,
                TileManager.TYPE.OBJECT
            };

            for (int i = 0; i < _tileType.Count; i ++)
            {
                SetTileButton(_tileType[i]);
            } 
        }

        /// <summary>
        /// Set tile button.
        /// </summary>
        /// <param name="_type">Tile type.</param>
        private void SetTileButton(TileManager.TYPE _type)
        {
            int maxNum = TileManager.GetMaxNumber(_type);

            for (int i = 0; i < maxNum; i++)
            {
                var tileInstance = Instantiate(tileButton) as GameObject;
                var tileComponent = tileInstance.GetComponent<TileMenu.TileSelectButton>();

                tileComponent.SetParent(this.gameObject);
                tileComponent.InitTile(_type, i);
                tileMenuGrid.repositionNow = true;
                tileInstance.transform.SetParent(tileMenuGrid.transform, false);
                tileButtons.Add(tileInstance);
            }
        }
        
        #endregion Private Methods
    }
}

