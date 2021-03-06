﻿namespace redd096
{
    using UnityEngine;

#if UNITY_EDITOR

    using UnityEditor;

    [CustomEditor(typeof(GridColorMap))]
    public class GridBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(10);

            if (GUILayout.Button("Regen Grid"))
            {
                ((GridColorMap)target).RegenGrid();

                //set undo
                Undo.RegisterFullObjectHierarchyUndo(target, "Regen Grid");
            }

            if(GUILayout.Button("Destroy Grid"))
            {
                ((GridColorMap)target).DestroyGrid();

                //set undo
                Undo.RegisterFullObjectHierarchyUndo(target, "Destroy Grid");
            }
        }
    }

#endif

    [AddComponentMenu("redd096/TileGrid/Grid Color Map")]
    public class GridColorMap : GridBase
    {
        [Header("Color Map")]
        [Tooltip("When import texture, set Non-Power of 2 to None, and enable Read/Write")] [SerializeField] Texture2D gridImage = default;
        [SerializeField] TileColorMap[] tiles = default;

        protected override TileBase GetTilePrefab(int x, int y, out Quaternion rotation)
        {
            //get color in texture2D
            Color color = gridImage.GetPixel(x, y);

            //foreach tile in list, find tile with this color (only R and G)
            foreach(TileColorMap tile in tiles)
            {
                if (tile.tileColor.r == color.r && tile.tileColor.g == color.g)
                {
                    //rotate using B
                    float angle = color.b * 360;
                    rotation = Quaternion.AngleAxis(angle, Vector3.up);

                    return tile;
                }
            }

            rotation = Quaternion.identity;
            return null;
        }

        public void RegenGrid()
        {
            //remove old grid and generate new one
            RemoveOldGrid();
            GenerateGrid(gridImage.width, gridImage.height);
        }

        public void DestroyGrid()
        {
            //remove old grid
            RemoveOldGrid();
        }
    }
}