using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maptool.Component;

namespace Maptool.TileMenu
{
    public class TileSelectButton : MonoBehaviour
    {
        #region Public Feild

        public TileSelectMenu menu   = null;
        public UISprite       sprite = null;
        public GameObject     frame  = null;

        #endregion Public Feild

        #region Public Property

        public bool       Selected   { get; set; }
        public Tile       TileInfo   { get; private set; }
        public GameObject Parent     { get; private set; }

        #endregion Public Property

        #region Public Methods

        public void Start()
        {
            menu = Parent.GetComponent<TileSelectMenu>();
            sprite.spriteName = TileInfo.Name;
        }

        public void SetParent(GameObject _obj)
        {
            Debug.Log("SetParent : " + _obj);
            Parent = _obj;
        }

        public void InitTile(TileManager.TYPE _type, int _num)
        {
            TileInfo = new Tile();
            TileInfo.Init(_type, _num);
        }

        public void OnClick()
        {
            menu.SetSelectedTile(TileInfo.Name);
            SetSelectStatus(true);
        }

        public void SetSelectStatus(bool _select)
        {
            Selected = _select;
            frame.SetActive(_select);
        }

        #endregion Public Methods

        #region Private Methods

        

        #endregion Private Methods
    }
}
