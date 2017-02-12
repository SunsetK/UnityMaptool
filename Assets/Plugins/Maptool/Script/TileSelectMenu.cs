using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maptool.Component;

namespace Maptool
{
    public class TileSelectMenu : UIManager
    {
        #region Public Field

        public UISprite         selectedSprite = null;
        public UIGrid           tileMenuGrid   = null;
        public GameObject       tileButton     = null;
        public List<GameObject> tileButtons    = new List<GameObject>();

        #endregion Public Field

        #region Public Methods

        public void Start()
        {
            InitTileSet();
        }

        public void SetSelectedTile(string _name)
        {
            for (int i = 0; i < tileButtons.Count; i++)
            {
                tileButtons[i].GetComponent<TileMenu.TileSelectButton>().SetSelectStatus(false);
            }
            
            selectedSprite.spriteName = _name;
        }

        #endregion Public Methods

        #region Private Methods

        private void InitTileSet()
        {
            List<TileManager.TYPE> _tileType = new List<TileManager.TYPE>
            {
                TileManager.TYPE.GROUND, TileManager.TYPE.PATH,
                TileManager.TYPE.WATER,  TileManager.TYPE.OBJECT
            };

            for (int i = 0; i < _tileType.Count; i ++)
            {
                SetTileButton(_tileType[i]);
            } 
        }

        private void SetTileButton(TileManager.TYPE _type)
        {
            int maxNum = TileManager.GetMaxNumber(_type);

            for (int i = 0; i < maxNum; i++)
            {
                var tileInstance = Instantiate(tileButton) as GameObject;
                var tileComponent = tileInstance.GetComponent<TileMenu.TileSelectButton>();
                Debug.Log("tileComponent : " + tileComponent);
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

