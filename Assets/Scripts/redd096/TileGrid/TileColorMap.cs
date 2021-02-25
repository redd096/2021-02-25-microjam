namespace redd096
{
    using UnityEngine;

    [AddComponentMenu("redd096/TileGrid/Tile Color Map")]
    [SelectionBase]
    public class TileColorMap : TileBase
    {
        [Header("Color Map")]
        public Color tileColor = Color.white;

        //255, 255 = floor
        //0, 0 = wall
        //0, 255 = endPoint
        //0, 100 = player spawn
        //255, 0 = enemy stationary
        //100, 0 = enemy mobile
    }
}