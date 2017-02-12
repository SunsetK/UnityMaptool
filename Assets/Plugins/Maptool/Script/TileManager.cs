using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Maptool.Config.Constants;

namespace Maptool
{
    public class TileManager : MonoBehaviour
    {
        #region Public Field
        public static UIAtlas mapResourcesAtlas = null;

        public enum TYPE
        {
            EMPTY,
            GROUND,
            PATH,
            WATER,
            OBJECT
        };

        public enum ROTATION
        {
            DEFAULT,
            ROT90,
            ROT180,
            ROT270
        };

        public enum REVERS
        {
            DEFAULT,
            REVERS
        };

        #endregion Public Field

        #region Public Methods

        public void Awake()
        {
            mapResourcesAtlas = Resources.Load(PATH.MAP_ATLAS_PATH, typeof(UIAtlas)) as UIAtlas;
        }

        /// <summary>
        /// Get tile name.
        /// </summary>
        /// <param name="type">Tile type.</param>
        /// <param name="num">Tile number.</param>
        /// <returns>Absolut tile name.</returns>
        public static string GetTileName(TYPE _type, int _num = -1)
        {
            string tileName = GetTypeName(_type);

            if (CheckValidNumber(_type, _num))
            {
                if (!IsSingleType(_type)) // 만약 싱글타입 타일이 아닐경우, 넘버를 붙여줌.
                {
                    tileName += _num.ToString("D2");
                }
            }
            else
            {
                Debug.Log("error! : check tile number.");
            }

            return tileName;
        }

        /// <summary>
        /// Check vaild numbr.
        /// </summary>
        /// <param name="type">Tile type.</param>
        /// <param name="num">Tile number.</param>
        /// <returns>t : is valid number, f : is invalid number.</returns>
        public static bool CheckValidNumber(TYPE _type, int _num = -1)
        {
            if (_num >= 0 && _num < GetMaxNumber(_type))
            {
                return true;
            }
            else if (IsSingleType(_type))
            {
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Is single type.
        /// </summary>
        /// <param name="type">Tile type.</param>
        /// <returns>t : is single type, f : isn't single tupe.</returns>
        public static bool IsSingleType(TYPE _type)
        {
            // 싱글타입 타일이 생길 때 마다 추가...
            if (_type == TYPE.EMPTY) return true;

            return false;
        }

        /// <summary>
        /// Get tile type name.
        /// </summary>
        /// <param name="type">Tile type.</param>
        /// <returns>Tile type name.</returns>
        public static string GetTypeName(TYPE _type)
        {
            switch (_type)
            {
                case TYPE.EMPTY:
                    return TILE_INFO.NAME.EMPTY;
                case TYPE.GROUND:
                    return TILE_INFO.NAME.GROUND;
                case TYPE.PATH:
                    return TILE_INFO.NAME.PATH;
                case TYPE.WATER:
                    return TILE_INFO.NAME.WATER;
                case TYPE.OBJECT:
                    return TILE_INFO.NAME.OBJECT;
            }

            return null;
        }

        /// <summary>
        /// Get max number in tile.
        /// </summary>
        /// <param name="type">Tile type.</param>
        /// <returns>Tile max number.</returns>
        public static int GetMaxNumber(TYPE _type)
        {
            switch (_type)
            {
                case TYPE.GROUND:
                    return TILE_INFO.MAX_NUMBER.GROUND;
                case TYPE.PATH:
                    return TILE_INFO.MAX_NUMBER.PATH;
                case TYPE.WATER:
                    return TILE_INFO.MAX_NUMBER.WATER;
                case TYPE.OBJECT:
                    return TILE_INFO.MAX_NUMBER.OBJECT;
            }

            return -1;
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
