using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Maptool.Config.Constants
{
    /// <summary>
    /// path.
    /// </summary>
    public class PATH
    {
        public static readonly string MAP_ATLAS_PATH = "Sprites/Atlas/MapResourcesAtlas";
    }

    /// <summary>
    /// Tile information.
    /// </summary>
    public class TILE_INFO
    {
        /// <summary>
        /// Tile type.
        /// </summary>
        public class NAME
        {
            public static readonly string EMPTY  = "frame"; // single type tile.
            public static readonly string GROUND = "tile";
            public static readonly string PATH   = "path";
            public static readonly string WATER  = "water";
            public static readonly string OBJECT = "obj";

            public static readonly List<string> NAMES = new List<string> 
            { 
                GROUND, PATH, WATER, OBJECT
            };
        }

        /// <summary>
        /// Tile max number.
        /// </summary>
        public class MAX_NUMBER
        {
            public static int GROUND = 4;
            public static int PATH   = 4;
            public static int WATER  = 9;
            public static int OBJECT = 2;
        }
    }
}